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
    
    public partial class Student
    {
        public int ID { get; set; }
        public int School_ticket_number { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public System.DateTime Birthday { get; set; }
        public decimal Class { get; set; }
        public string Direction { get; set; }
        public decimal Telephone { get; set; }
        public string Email { get; set; }
    
        public virtual Instances Instances { get; set; }
    }
}