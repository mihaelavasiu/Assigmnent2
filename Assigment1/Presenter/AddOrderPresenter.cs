using Assigment1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment1.Presenter
{
    public class AddOrderPresenter
    {
        public AddOrder addOrderView;
        public AddOrderModel viewManagerModel;
        public Assigment1.AddOrder addOrder;

        public AddOrderPresenter(Assigment1.AddOrder addOrder)
        {
            this.addOrderView = addOrder;
            viewManagerModel=new AddOrderModel(this);
        }
        public void AddOrder(){
            viewManagerModel.AddOrder();
        }

        public void LoadAddOrder()
        {
            viewManagerModel.LoadAddOrder();
        }
    }
}
