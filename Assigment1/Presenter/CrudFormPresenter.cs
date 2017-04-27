using Assigment1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment1.Presenter
{
    public class CrudFormPresenter
    {
        public CrudForm crudFormView;
        public CrudFormModel viewCrudModel;
        public Assigment1.CrudForm crudForm;

        public CrudFormPresenter(CrudForm crudForm)
        {
            this.crudFormView = crudForm;
            viewCrudModel = new CrudFormModel(this);
        }
        public void CrudForm_Load()
        {
            viewCrudModel.CrudForm_Load();
        }

        public void btnAdd_Click()
        {
            viewCrudModel.btnAdd_Click();
        }

        public void button3_Click()
        {
            viewCrudModel.button3_Click();
        }

        public void button1_Click()
        {
            viewCrudModel.button1_Click();
        }

        public void button2_Click()
        {
            viewCrudModel.button2_Click();
        }

       
    }
}
