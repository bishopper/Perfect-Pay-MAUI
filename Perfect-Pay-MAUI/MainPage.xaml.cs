namespace Perfect_Pay_MAUI;

public partial class MainPage : ContentPage
{
    decimal bill;
    int tip;
    int personNumber = 1;

    public MainPage()
    {
        InitializeComponent();
    }
    private void Calculate()
    {
        var totalTip = (bill * tip) / 100;
        var tipPerPerson = totalTip / personNumber;
        tipLabelPerson.Text = $"{tipPerPerson:C}";

        var subTotal = bill / personNumber;
        subTotalLabel.Text = $"{subTotal:C}";

        var total = subTotal + tipPerPerson;
        totalLabel.Text = $"{total:C}";
    }
    private void billText_Completed(object sender, EventArgs e)
    {
        bill = decimal.Parse(billText.Text);
        Calculate();
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip = (int)tipSlider.Value;
        tipLabel.Text = $"Tip : {tip}%";
        Calculate();

    }

    private void plusBtn_Clicked(object sender, EventArgs e)
    {
        personNumber++;
        personNumberText.Text = personNumber.ToString();
        Calculate();
    }

    private void minusBtn_Clicked(object sender, EventArgs e)
    {
        if(personNumber>1)
        {
            personNumber--;
        }
        personNumberText.Text = personNumber.ToString();
        Calculate();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        var persentage = int.Parse(btn.Text.Replace("%", ""));
        tipSlider.Value = persentage;
    }
}

