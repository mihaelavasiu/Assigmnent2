using Assigment1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment1.Presenter
{
    public class AddFormPresenter
    {
        public AddForm addFormView;
        public AddFormModel viewManagerModel;
        public Assigment1.AddForm addForm;

        public AddFormPresenter(Assigment1.AddForm addForm)
        {
            this.addFormView = addForm;
            viewManagerModel=new AddFormModel(this);
        }
        public void AddForm(){
            viewManagerModel.AddForm();
        }

        public void LoadAddForm()
        {
            viewManagerModel.LoadAddForm();
        }
    }
}
