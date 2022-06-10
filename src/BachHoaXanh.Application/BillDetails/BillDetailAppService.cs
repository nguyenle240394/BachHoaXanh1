using BachHoaXanh.Bills;
using BachHoaXanh.Customers;
using BachHoaXanh.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BachHoaXanh.BillDetails
{
    public class BillDetailAppService : ApplicationService, IBillDetailAppService
    {
        private readonly IBillDetailRepository _billDetailRepository;
        private readonly IBillRepository _billRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public BillDetailAppService(IBillDetailRepository billDetailRepository, IBillRepository billRepository, 
            ICustomerRepository customerRepository,
            IProductRepository productRepository)
        {
            _billDetailRepository = billDetailRepository;
            _billRepository = billRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<BillDetailDto> CreateAsync(CreateUpdateBillDetail input)
        {
            var billDetail = ObjectMapper.Map<CreateUpdateBillDetail, BillDetail>(input);
            await _billDetailRepository.InsertAsync(billDetail);
            return ObjectMapper.Map<BillDetail, BillDetailDto>(billDetail);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var billDetail = await _billDetailRepository.FindAsync(id);
            await _billDetailRepository.DeleteAsync(billDetail);
            return true;
        }

        public async Task<PagedResultDto<BillDetailDto>> GetListAsync(GetBillDetailInput input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(BillDetail.CreationTime);
            }
            var billDetail = await _billDetailRepository.GetListAsync(
                    input.SkipCount,
                    input.MaxResultCount,
                    input.Sorting,
                    input.Filter
                );
            var billDetaildto = ObjectMapper.Map<List<BillDetail>, List<BillDetailDto>>(billDetail);
            var count = billDetaildto.Count();
            for (int i = 0; i <= count -1; i++)
            {
                    var customer = await GetCustomerIdAsync(billDetaildto[i].BillId);
                    billDetaildto[i].CustomerId = customer.Id;
            }
            


            var productDictionary = await GetProductDictionaryAsync(billDetail);
            billDetaildto.ForEach(billdetaildto => billdetaildto.ProductName = productDictionary[billdetaildto.ProductId].Name);



            var customerDictionary = await GetCustomerDictionaryAsync(billDetail);
            billDetaildto.ForEach(b => b.CustomerName = customerDictionary[b.CustomerId].Name);




            var total = await _billDetailRepository.GetCountAsync();
            return new PagedResultDto<BillDetailDto>(
                    total,
                    billDetaildto
                );
        }

        private async Task<Customer> GetCustomerIdAsync(Guid id)
        {
            var bill = await _billRepository.FindAsync(id);
            var customer = await _customerRepository.FindAsync(bill.CustomerId);
            return customer;
        }
        private async Task<Dictionary<Guid, Customer>> GetCustomerDictionaryAsync(List<BillDetail> billDetails)
        {
            var bills = new List<Bill>();
            foreach (var item in billDetails)
            {
                var bill = await _billRepository.GetAsync(item.BillId);
                bills.Add(bill);
            }
            var customerIds = bills
                .Select(b => b.CustomerId)
                .Distinct()
                .ToArray();

            var queryable = await _customerRepository.GetQueryableAsync();
            var customers = await AsyncExecuter.ToListAsync(queryable.Where(s => customerIds.Contains(s.Id)));
            return customers.ToDictionary(x => x.Id, x => x);
        }

        private async Task<Dictionary<Guid, Product>> GetProductDictionaryAsync(List<BillDetail> billDetails)
        {
            var productIds = billDetails
                .Select(b => b.ProductId)
                .Distinct()
                .ToArray();

            var queryable = await _productRepository.GetQueryableAsync();
            var products = await AsyncExecuter.ToListAsync(queryable.Where(s => productIds.Contains(s.Id)));
            return products.ToDictionary(x => x.Id, x => x);
        }

        public async Task<BillDetailDto> UpdateAsync(Guid id, CreateUpdateBillDetail input)
        {
            var billDetail = await _billDetailRepository.FindAsync(id);
            billDetail.BillId = input.BillId;
            billDetail.ProductId = input.ProductId;
            billDetail.Quantity = input.Quantity;
            await _billDetailRepository.UpdateAsync(billDetail);
            return ObjectMapper.Map<BillDetail, BillDetailDto>(billDetail);
        }

        public async Task<List<BillDetailDto>> CreateBillDetailAsync(Guid billId, List<Guid> productIds)
        {
            var billDetails = new List<BillDetail>();
            foreach (var productid in productIds)
            {
                var billDetail = await _billDetailRepository.GetBillDetail(billId, productid);
                await _billDetailRepository.InsertAsync(billDetail);
                billDetails.Add(billDetail);
            }
            var billDetailDtos = ObjectMapper.Map<List<BillDetail>, List<BillDetailDto>>(billDetails);
            return billDetailDtos;
        }
    }
}
