using Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities.Abstract
{
 public abstract  class BaseEntity
    {
        public int ID { get; set; }

        private DateTime _createdDate = DateTime.Now;
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        public DateTime? ModifiedDate { get; set; }  // ? => nullable 

        public DateTime? RemovedDate { get; set; }


        private Statu _status = Statu.Active;

        public Statu Statu
        {
            get { return _status; }
            set { _status = value; }
        }

       
    }
}
