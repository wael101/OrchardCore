using System.ComponentModel.DataAnnotations;

namespace OrchardCore.AdminTrees.ViewModels
{
    public class AdminTreeCreateViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
