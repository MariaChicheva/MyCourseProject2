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
    
    public partial class Account
    {
        public int AccountID { get; set; }
        public string Login_ { get; set; }
        public string Password_ { get; set; }
        public Nullable<int> RoleID { get; set; }
    
        public virtual Role_ Role_ { get; set; }
    }
}
