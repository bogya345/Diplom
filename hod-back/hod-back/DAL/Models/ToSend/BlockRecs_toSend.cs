using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using hod_back.DAL.Models;
using hod_back.DAL.Models.Dictionaries;
using hod_back.DAL;

namespace hod_back.DAL.Models.ToSend
{
    public class BlockRecs_toSend
    {
        public int id_blockRec { get; set; }

        public int id_group { get; set; }

        public int semestrNum { get; set; }

        public int InPlan { get; set; }

        public string subject { get; set; }

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

        public BlockRecs_toSend() { }

        public BlockRecs_toSend(UnitOfWork db, BlockRecs origin)
        {
            id_blockRec = origin.id_blockRec;
            id_group = origin.id_group;
            semestrNum = origin.semestrNum;
            InPlan = origin.InPlan;

            subject = db.Subjects.GetAll().Where(x => x.ID == origin.id_subject).FirstOrDefault().NAME;

            blockNum = origin.blockNum;
            ze = origin.ze;
            total = origin.total;
            les = origin.les;
            lab = origin.lab;
            pr = origin.pr;
            iz = origin.iz;
            ak = origin.ak;
            kpr = origin.kpr;
            sr = origin.sr;
            controll = origin.controll;

        }

    }
}
