using System.ComponentModel.DataAnnotations;

namespace ToDo.Models;

public class Item
{
    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo Descrição é obrigatório")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo Data é obrigatório")]
    [DataType(DataType.Date)]
    [CustomValidation(typeof(Item), nameof(DataValidation))]
    public DateTime Date { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "O campo Horário é obrigatório")]
    public string Hour { get; set; } = string.Empty;

    public DateTime CreatedDate { get; private set; } = DateTime.Today;
    public bool IsFinished { get; set; } = false;

    public bool IsFinishedStyle()
    {
        var currentHour = TimeSpan.Parse(Hour);

        return IsFinished == true || Date < DateTime.Today || currentHour < DateTime.Now.TimeOfDay;
    }
    
    public static ValidationResult DataValidation(DateTime date, ValidationContext context)
    {
        if (date < DateTime.Today)
        {
            return new ValidationResult("A data não pode estar no passado.");
        }

        return ValidationResult.Success!;
    }
    
}