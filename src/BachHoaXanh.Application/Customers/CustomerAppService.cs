using BachHoaXanh.Bills;
using BachHoaXanh.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BachHoaXanh.Customers
{
    [Authorize(BachHoaXanhPermissions.Customers.Default)]
    public class CustomerAppService : ApplicationService, ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBillRepository _billRepository;

        public CustomerAppService(ICustomerRepository customerRepository, IBillRepository billRepository)
        {
            _customerRepository = customerRepository;
            _billRepository = billRepository;
        }
        public async Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto input)
        {
            var customer = ObjectMapper.Map<CreateUpdateCustomerDto, Customer>(input);
            await _customerRepository.InsertAsync(customer);

            return ObjectMapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var customer = await _customerRepository.FindAsync(id);
            var bill = await _billRepository.AnyAsync(b => b.CustomerId == id);
            if (bill)
            {
                return false;
            }
            await _customerRepository.DeleteAsync(customer);
            return true;
        }

        public async Task<CustomerDto> GetCustomerAsync(Guid id)
        {
            var customer = await _customerRepository.FindAsync(id);
            return ObjectMapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task<PagedResultDto<CustomerDto>> GetListAsync(GetCustomerInput input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Customer.Name);
            }

            var customers = await _customerRepository.GetListAsync(
                    input.SkipCount,
                    input.MaxResultCount,
                    input.Sorting,
                    input.Filter
                );

            var totalCount = await _customerRepository.GetCountAsync();

            return new PagedResultDto<CustomerDto>(
                    totalCount,
                    ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customers)
                );
        }

        public async Task<CustomerDto> UpdateAsync(Guid id, CreateUpdateCustomerDto input)
        {
            var customer = await _customerRepository.FindAsync(id);
            customer.Name = input.Name;
            customer.BirthDay = input.BirthDay;
            customer.PhoneNumber = input.PhoneNumber;
            customer.Address = input.Address;
            await _customerRepository.UpdateAsync(customer);
            return ObjectMapper.Map<Customer, CustomerDto>(customer);
        }
    }
}
