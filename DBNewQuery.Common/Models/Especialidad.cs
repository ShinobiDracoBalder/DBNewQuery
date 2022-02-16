using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DBNewQuery.Common.Models
{
    public class Especialidad
    {
        [Key]
        //[JsonProperty("EspecialidadId")]
        public int EspecialidadId { get; set; }
        [Required]
        //[JsonProperty("EspecialidadNombre")]
        public string EspecialidadNombre { get; set; }
    }
}
