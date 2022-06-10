using BachHoaXanh.BillDetails;
using BachHoaXanh.Customers;
using BachHoaXanh.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BachHoaXanh.Bills
{
    public class BillAppService : ApplicationService, IBillAppService
    {
        private readonly IBillRepository _billRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBillDetailRepository _billDetailRepository;

        public BillAppService(IBillRepository billRepository, 
            ICustomerRepository customerRepository, 
            IProductRepository productRepository, 
            IBillDetailRepository billDetailRepository )
        {
            _billRepository = billRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _billDetailRepository = billDetailRepository;
        }
        public async Task<BillDto> CreateAsync(CreateUpdateBillDto input)
        {
            var bill = ObjectMapper.Map<CreateUpdateBillDto, Bill>(input);
            await _billRepository.InsertAsync(bill);
            return ObjectMapper.Map<Bill, BillDto>(bill);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var bill = await _billRepository.FindAsync(id);
            var billdetail = await _billDetailRepository.AnyAsync(x => x.BillId == id);
            if (billdetail)
            {
                return false;
            }
            await _billRepository.DeleteAsync(bill);
            return true;
        }

        public async Task<BillDto> GetBillAsync(Guid id)
        {
            var bill = await _billRepository.FindAsync(id);
            return ObjectMapper.Map<Bill, BillDto>(bill);
        }

        /*public async Task<ListResultDto<CustomerLookup>> GetCustomerLookup()
        {
            var customer = await _customerRepository.GetListAsync();
            return new ListResultDto<CustomerLookup>(
                    *//*ObjectMapper.Map<List<Customer>, List<CustomerLookup>>(customer)*//*
                );
        }*/

        public async Task<PagedResultDto<BillDto>> GetListAsync(GetBillInput input)
        {
            var bills = await _billRepository.GetListAsync(
                    input.SkipCount,
                    input.MaxResultCount,
                    input.Sorting,
                    input.Filter
                );
            var billDtos = ObjectMapper.Map<List<Bill>, List<BillDto>>(bills);
            var customerDictionry = await GetCustomerDictionaryAsync(bills);
            billDtos.ForEach(billDto => billDto.CustomerName = customerDictionry[billDto.CustomerId].Name);

            /*var count = billDtos.Count();
            for (int i = 0; i <= count; i++)
            {
                var billdetails = await GetListBillDetailAsync(billDtos[i].Id);

                billDtos = billdetails
            }*/

            foreach (var item in billDtos)
            {
                var billdetails = await GetListBillDetailAsync(item.Id);

                var billdetailId = billdetails
                    .Select(b => b.Id)
                    .ToList();
                item.BillDetailIDs = billdetailId;
            }

            foreach (var item in billDtos)
            {
                var productName = await GetNameProductAsync(item.BillDetailIDs);
                item.ProductNames = productName;
            }

            
            var totalCount = await _billRepository.GetCountAsync();

            return new PagedResultDto<BillDto>(
                    totalCount,
                    billDtos
                );
        }

        public async Task<List<BillDto>> GetListBillAsync()
        {
            var bills = await _billRepository.GetListAsync();
            var billDtos = ObjectMapper.Map<List<Bill>, List<BillDto>>(bills);
           /* var customerDictionry = await GetCustomerDictionaryAsync(bills);
            billDtos.ForEach(billDto => billDto.CustomerName = customerDictionry[billDto.CustomerId].Name);*/
            return billDtos;
        }

        /*public async Task<ListResultDto<ProductLookup>> GetProductLookup()
        {
            var product = await _productRepository.GetListAsync();
            return new ListResultDto<ProductLookup>(
                    ObjectMapper.Map<List<Product>, List<ProductLookup>>(product)
                );
        }*/

        public async Task<BillDto> UpdateAsync(Guid id, CreateUpdateBillDto input)
        {
            var bill = await _billRepository.FindAsync(id);
            bill.CustomerId=input.CustomerId;
            
            await _billRepository.UpdateAsync(bill);
            return ObjectMapper.Map<Bill, BillDto>(bill);
            
        }


        private async Task<Dictionary<Guid, Customer>> GetCustomerDictionaryAsync(List<Bill> bills)
        {
            var customerIds = bills
                .Select(c => c.CustomerId)
                .Distinct()
                .ToArray();

            var queryable = await _customerRepository.GetQueryableAsync();
            var suppliers = await AsyncExecuter.ToListAsync(queryable.Where(s => customerIds.Contains(s.Id)));
            return suppliers.ToDictionary(x => x.Id, x => x);
        }

        /* private async Task<Dictionary<Guid, Product>> GetProductDictionaryAsync(List<Bill> bills)
         {
             var products = bills
                 .Select(c => c.ProductId)
                 .Distinct()
                 .ToArray();

             var queryable = await _productRepository.GetQueryableAsync();
             var suppliers = await AsyncExecuter.ToListAsync(queryable.Where(s => products.Contains(s.Id)));
             return suppliers.ToDictionary(x => x.Id, x => x);
         }*/

        private async Task<List<string>> GetNameProductAsync(List<Guid> id)
        {
            var productName = new List<string>();
            foreach (var item in id)
            {
                var billdetail = await _billDetailRepository.FindAsync(item);
                var product = await _productRepository.FindAsync(billdetail.ProductId);
                productName.Add(product.Name);
            }
            return productName;
        }
        private async Task<List<BillDetail>> GetListBillDetailAsync(Guid id)
        {
            var queryable = await _billDetailRepository.GetQueryableAsync();
                var query = queryable
                .Where(x => x.BillId == id);
                var billdetils = await AsyncExecuter.ToListAsync(query);
          
            return billdetils;
        }

        public async Task<ListResultDto<CustomerLookupDto>> GetCustomerLookupAsync()
        {
            var customer = await _customerRepository.GetListAsync();

            var customerLokkupDto = ObjectMapper.Map<List<Customer>, List<CustomerLookupDto>>(customer);

            return new ListResultDto<CustomerLookupDto>(
                    customerLokkupDto
                );
        }

        public async Task<ListResultDto<ProductLookupDto>> GetProductLookupAsync()
        {
            var product = await _productRepository.GetListAsync();
            var productDto = ObjectMapper.Map<List<Product>, List<ProductLookupDto>>(product);
            return new ListResultDto<ProductLookupDto>(
                    productDto
                );
        }

        public async Task<BillDto> GetLastIdAsync()
        {
            var bills = await _billRepository.GetListAsync();
            var count = bills.Count() - 1;
            var billIdLast = await _billRepository.FindAsync(bills[count].Id);
            return ObjectMapper.Map<Bill, BillDto>(billIdLast);
            
        }
    }
}
