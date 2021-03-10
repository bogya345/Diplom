using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace hod_back.DAL.Models
{
    [Table("BlockRecs", Schema = "dbo")]
    public class BlockRecs
    {
        [Key]
        public int id_blockRec { get; set; }

        [ForeignKey("Groups")]
        public int id_group { get; set; }

        public int semestrNum { get; set; }

        public int InPlan { get; set; }

        [ForeignKey("Subjects")]
        public int id_subject { get; set; }

        public string blockNum { get; set; }

        // з.е
        public double ze { get; set; }
        // итого
        public double total { get; set; }
        // лек
        public double les { get; set; }
        // лаб
        public double lab { get; set; }
        // пр
        public double pr { get; set; }
        // из
        public double iz { get; set; }
        // ак
        public double ak { get; set; }
        // кпр
        public double kpr { get; set; }
        // ср
        public double sr { get; set; }
        // контроль
        public double controll { get; set; }

        public BlockRecs() { }


        [NotMapped]
        public bool IsEmpty { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"> 0 - id_group | 1 - semestr | 2 - InPlan | 3 - id_subject | 4 - blockNum | 5...</param>
        public BlockRecs(params string[] args)
        {
            int i = 0;

            id_group = Convert.ToInt32(args[i]);

            semestrNum = Convert.ToInt32(args[++i]);

            InPlan = (args[++i] == "+" ? 1 : 0);

            id_subject = Convert.ToInt32(args[++i]);

            blockNum = args[++i];

            i++;
            ze = (args[i] != "") ? Convert.ToDouble(args[i]) : 0; i++;
            total = (args[i] != "") ? Convert.ToDouble(args[i]) : 0; i++;
            les = (args[i] != "") ? Convert.ToDouble(args[i]) : 0; i++;
            lab = (args[i] != "") ? Convert.ToDouble(args[i]) : 0; i++;
            pr = (args[i] != "") ? Convert.ToDouble(args[i]) : 0; i++;
            iz = (args[i] != "") ? Convert.ToDouble(args[i]) : 0; i++;
            ak = (args[i] != "") ? Convert.ToDouble(args[i]) : 0; i++;
            kpr = (args[i] != "") ? Convert.ToDouble(args[i]) : 0; i++;
            sr = (args[i] != "") ? Convert.ToDouble(args[i]) : 0; i++;
            controll = (args[i] != "") ? Convert.ToDouble(args[i]) : 0; i++;


            double sum = 0;
            for (int j = 5; j < args.Length; j++)
            {
                sum += (args[j] != "") ? Convert.ToDouble(args[j]) : 0;
            }

            IsEmpty = (sum == 0);
        }

    }
}
