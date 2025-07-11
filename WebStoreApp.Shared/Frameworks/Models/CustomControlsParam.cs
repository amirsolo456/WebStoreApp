using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreApp.Shared.Frameworks.Models
{
    public class CustomControlsBaseClass
    {
        [Required]
        public int ID { get; set; }
        public string Type { get; set; }
        public CustomControlsPrameter Inputs { get; set; }
        public CustomSelectBox SelectBoxes { get; set; }
    }


    public record CustomControlsPrameter(string Type = "Text")
    {
        [Parameter]
        public string? Placeholder { get; set; }
        public List<CustomControlsPrameter> Options { get; set; }
        [Parameter]
        public string? Value { get; set; }
        public string? Label { get; set; }
        public string? FieldName { get; set; }
        [Parameter]
        public string? ErroreMessage { get; set; }
        [Parameter]
        public Expression<Func<object>>? For { get; set; }
        //public string Type { get; set; } = "Text";
        public Dictionary<string, object> inputAttributes => new()
        {
            ["type"] = Type
        };

        public EventHandler<CustomControlsPrameter> SelectAction { get; set; }
    }

    public partial class CustomSelectBox(string Type)  
    {
        [Required]
        public string ID { get; set; }
        public string Label { get; set; }
        public string? Value { get; set; }
        public string? FieldName { get; set; }
        [Required]
        public string Especialidad { get; set; }
        public Dictionary<string, object> inputAttributes => new()
        {
            ["type"] = Type
        };
        public EventHandler<CustomControlsPrameter> SelectAction { get; set; }
    }


    public record EditFormFieldsPropertys
    {
        public IEnumerable<CustomControlsPrameter> Inputs { get; set; }
        public IEnumerable<CustomSelectBox> SelectBoxes { get; set; }
    }
}
