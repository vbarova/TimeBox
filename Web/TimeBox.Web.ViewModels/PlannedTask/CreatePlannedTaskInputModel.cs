namespace TimeBox.Web.ViewModels.PlannedTask
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreatePlannedTaskInputModel
    {
        [Required]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Начален час")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Очакван час на приключване")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Описание на задачата")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
