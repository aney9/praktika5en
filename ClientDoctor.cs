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
    
    public partial class ClientDoctor
    {
        public int ID_clientdoctor { get; set; }
        public int doctors_ID { get; set; }
        public int clients_ID { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Doctors Doctors { get; set; }
    }
}
