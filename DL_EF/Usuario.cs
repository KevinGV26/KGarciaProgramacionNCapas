//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Direccions = new HashSet<Direccion>();
        }
    
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public Nullable<int> IdRol { get; set; }
        public string password { get; set; }
        public string sexo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string Curp { get; set; }
        public string Imagen { get; set; }
        public string UserName { get; set; }
        public Nullable<bool> status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Direccion> Direccions { get; set; }
        public virtual Rol Rol { get; set; }
    }
}