//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetails
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string UnitPrice { get; set; }
        public int OrderId { get; set; }
    
        public virtual Orders Orders { get; set; }
    }
}
