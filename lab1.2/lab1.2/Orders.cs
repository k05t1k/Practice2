//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lab1._2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int ID_Orders { get; set; }
        public decimal Price { get; set; }
        public int Client_ID { get; set; }
        public int Personal_ID { get; set; }
        public int Pizza_ID { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Personal Personal { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
