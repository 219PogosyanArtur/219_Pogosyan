//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _219_Pogosyan
{
    using System;
    using System.Collections.Generic;
    
    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            this.Instances = new HashSet<Instances>();
        }
    
        public int ID { get; set; }
        public int ISBN { get; set; }
        public string Autor { get; set; }
        public string Name { get; set; }
        public System.DateTime Year_of_publication { get; set; }
        public string Publishing_house { get; set; }
        public string Subject { get; set; }
        public int Number_of_pages { get; set; }
        public int ID_Area { get; set; }
    
        public virtual Area_Of_Expertise Area_Of_Expertise { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Instances> Instances { get; set; }
    }
}