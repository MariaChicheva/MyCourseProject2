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
    
    public partial class Item
    {
        public Item()
        {
            this.Jeweler = new HashSet<Jeweler>();
        }
    
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> ItemWeight { get; set; }
        public Nullable<int> ItemSize { get; set; }
        public Nullable<int> ItemType { get; set; }
        public Nullable<int> ItemMaterial { get; set; }
    
        public virtual Material Material { get; set; }
        public virtual Types_ Types_ { get; set; }
        public virtual ICollection<Jeweler> Jeweler { get; set; }
    }
}
