//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompanyApp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Company
    {
        public int Id { get; set; }
        public Nullable<int> CityId { get; set; }
        public string WorkingShift { get; set; }
    
        public virtual City City { get; set; }
    }
}
