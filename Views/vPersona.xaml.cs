using rtoasa5.Models;

namespace rtoasa5.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.PersonRepo.AddNewPerson(txtPersona.Text);
        lblStatus.Text= App.PersonRepo.statusMessage;
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        List<Persona> people=App.PersonRepo.GetAllPeople();
        Listapersonas.ItemsSource = people;
    }
}