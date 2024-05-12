using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.TenantsList
{
    public class Tenants
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int ServerId { get; set; }
        public string Code { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string Administration { get; set; }
        public string AuthorizedName { get; set; }
        public string AuthorizedPhoneNumber { get; set; }
        public string AuthorizedEmail { get; set; }
        public string? Explanation { get; set; }
        public Guid? DatabaseTypeId { get; set; }
        public bool IsSharedDatabase { get; set; }
        public string? ConnectionString { get; set; }
        public bool IsOnlyTenant { get; set; }
        public bool IsActive { get; set; }
        public string? IsNotActiveReason { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }

}
