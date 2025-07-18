using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace WebStoreApp.Shared.Frameworks.Models
{
    public class CustomControlsBaseClass
    {
        [Required]
        public int ID { get; set; }
        public string Type { get; set; }
        public CustomControlsPrameter<string> Inputs { get; set; }
        public CustomSelectBox SelectBoxes { get; set; }
    }


    public record CustomControlsPrameter<T>(string Type = "Text") 
    {
        public string? Placeholder { get; set; }
        private T? _value=default;
        public T? Value 
        { 
            get => _value;
            set
            {
                _value = value;
                OnValueChanged?.Invoke(this, value);
            }
        }
        public string? Label { get; set; }
        public string? FieldName { get; set; }
        public string? ErroreMessage { get; set; }
        public string? type { get; set; } = Type;
        public EventHandler<T>? OnValueChanged { get; set; }
        public int Delay { get; set; } = 2000;  
    }

    public   class CustomSelectBox(string Type)  
    {
        public string ID { get; set; }
        public string Label { get; set; }
        public string? Value { get; set; }
        public string? FieldName { get; set; }
        public string Especialidad { get; set; }
        public List<SelectBoxItem>? Options { get; set; }
        public Dictionary<string, object> inputAttributes => new()
        {
            ["type"] = Type
        };
        public EventHandler<SelectBoxItem> OnValueChanged { get; set; }
    }

    public record SelectBoxItem
    {
        public string ID { get; set; }
        public string Label { get; set; }
        public string? Value { get; set; }
        public string? FieldName { get; set; }
        public string Especialidad { get; set; }
    }


    //public record EditFormFieldsPropertys
    //{
    //    public IEnumerable<CustomControlsPrameter> Inputs { get; set; }
    //    public IEnumerable<CustomSelectBox> SelectBoxes { get; set; }
    //}
}
