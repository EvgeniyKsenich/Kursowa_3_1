//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KR.DbEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class land
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public land()
        {
            this.zakaz = new HashSet<zakaz>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int customer_id { get; set; }
        public int size { get; set; }
        public string addres { get; set; }
    
        public virtual customer customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zakaz> zakaz { get; set; }
    }
}
