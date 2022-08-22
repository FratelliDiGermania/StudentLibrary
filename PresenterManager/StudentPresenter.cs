using JT.UniStuttgart.StudentLibrary.Logic.DBManagement.DBManager.Services;
using JT.UniStuttgart.StudentLibrary.Models.ModellManager;
using JT.UniStuttgart.StudentLibrary.Views.InterfacesManager;

namespace JT.UniStuttgart.StudentLibrary.Logic.DBManagement.Presenter.PresenterManager
{
    public class StudentPresenter
    {
        IStudent View;
        Student Model = new Student();
        public StudentPresenter(IStudent view)
        {
            View = view;
            Model = new Student();
        }

        public void AddStudent()
        {
            ConnectModel2View();
            StudentServices.StudentInsert(Model.Name, Model.Address, Model.Phone.ToString());
        }
        public void GetStudent()
        {
            ConnectModel2View();
            StudentServices.StudentSelect();
        }
        void ConnectModel2View()
        {
            Model.ID = !string.IsNullOrEmpty(View?.IdText) ? int.Parse(View?.IdText) : -1;
            Model.Name = View.NameText;
            Model.Address = View.AddressText;
            //Model.Phone = !string.IsNullOrEmpty(View?.IdText) ? int.Parse(Model?.Phone) : -1;
        }
    }
}
