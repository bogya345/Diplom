using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto.Analyser.FgosRequirs
{
    public abstract class Requir : IRequir
    {
        /// <summary>
        /// Номер пунката ФГОС требования
        /// </summary>
        public string Num { get; set; }

        /// <summary>
        /// Описание без вставки значения направления
        /// </summary>
        public string Discription { get; set; }

        /// <summary>
        /// Описание с вставкой значения направления
        /// </summary>
        public string DiscriptionSetted
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.Discription))
                {
                    return this.Discription.Replace("*", this.Value.ToString());
                }
                return null;
            }
        }

        /// <summary>
        /// Значение направления
        /// </summary>
        public float Value
        {
            get
            {
                if (true) // проверка на едицину
                {
                    // процент
                    if (NumberSuitable == NumberAll) { return 100; }
                    return (float)Math.Round((double)(NumberSuitable * 100) / NumberAll, 2);
                }
            }
        }

        /// <summary>
        /// Требовательное значение (по ФГОС тербованию)
        /// </summary>
        public float? ValueNeeded { get; set; }

        /// <summary>
        /// Признак выполненого требования
        /// </summary>
        public bool isDone { get { return (Value >= ValueNeeded); } }

        /// <summary>
        /// Направление (мб не нужно)
        /// </summary>
        public DirectionDto Direction { get; set; }

        /// <summary>
        /// Количество объектов
        /// </summary>
        public double NumberAll { get; set; }

        /// <summary>
        /// Количество подходящих под требование объектов
        /// </summary>
        public double NumberSuitable { get; set; }

        public string Mark
        {
            get
            {
                return (NumberSuitable * 100) / NumberAll > ValueNeeded ? "+" : "-";
            }
        }
    }
}
