//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace e_commerce1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.Ventas = new HashSet<Ventas>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Fk_Presentacion { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<double> Precio { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Stock_Maximo { get; set; }
        public Nullable<int> Stock_Minimo { get; set; }
        public string Foto { get; set; }
        public Nullable<int> fk_categoria { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Presentacion Presentacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
