//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace praktika5
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrdersBill
    {
        public int ID_ordersbill { get; set; }
        public int bill_ID { get; set; }
        public int orders_ID { get; set; }
    
        public virtual Bill Bill { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
