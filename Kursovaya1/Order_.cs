//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursovaya1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_
    {
        public int OrderID { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        public Nullable<System.DateTime> DateAndTime_ { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> JewelerID { get; set; }
        public string Item { get; set; }
        public Nullable<int> StatusID { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Jeweler Jeweler { get; set; }
        public virtual Status Status { get; set; }
        public string Items { get; internal set; }
    }
}
