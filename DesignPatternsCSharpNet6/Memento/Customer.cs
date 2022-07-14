namespace DesignPatternsCSharpNet6.Memento;

public class Customer
{
    // Save a list of memento objects,
    // to allow for multiple "snapshots" of the Customer object.
    private readonly List<CustomerMemento> _customerMementos =
        new List<CustomerMemento>();

    public int ID { get; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string PostalCode { get; set; }

    public bool IsDirty
    {
        get
        {
            if (_customerMementos.Count == 0)
            {
                return false;
            }

            return Name != _customerMementos.First().Name ||
                   Address != _customerMementos.First().Address ||
                   City != _customerMementos.First().City ||
                   StateProvince != _customerMementos.First().StateProvince ||
                   PostalCode != _customerMementos.First().PostalCode;
        }
    }

    public Customer(int id, string name, string address,
        string city, string stateProvince, string postalCode)
    {
        ID = id;
        Name = name;
        Address = address;
        City = city;
        StateProvince = stateProvince;
        PostalCode = postalCode;

        // Save the originally-passed values to the memento list.
        SaveCurrentStateToMemento();
    }

    // The "Caretaker" functions
    public void SaveCurrentStateToMemento()
    {
        _customerMementos.Add(new CustomerMemento(this));
    }

    public void RevertToOriginalValues()
    {
        // Get the first memento, if there is one (there always should be at least one).
        var firstMemento = _customerMementos.FirstOrDefault();

        // Check for null, just to be safe.
        if (firstMemento != null)
        {
            SetPropertyValuesFromMemento(firstMemento);

            // Remove all the mementos, except for the first one.
            if (_customerMementos.Count > 1)
            {
                _customerMementos.RemoveRange(1, _customerMementos.Count - 1);
            }
        }
    }

    public void RevertToPreviousValues()
    {
        // Get the last memento, if there is one (there always should be at least one).
        var lastMemento = _customerMementos.LastOrDefault();

        // Check for null, just to be safe.
        if (lastMemento != null)
        {
            SetPropertyValuesFromMemento(lastMemento);

            // Remove the last memento, unless it's the first one.
            if (lastMemento != _customerMementos.First())
            {
                _customerMementos.Remove(lastMemento);
            }
        }
    }

    private void SetPropertyValuesFromMemento(CustomerMemento memento)
    {
        Name = memento.Name;
        Address = memento.Address;
        City = memento.City;
        StateProvince = memento.StateProvince;
        PostalCode = memento.PostalCode;
    }

    // The "Memento" class
    private class CustomerMemento
    {
        public string Name { get; }
        public string Address { get; }
        public string City { get; }
        public string StateProvince { get; }
        public string PostalCode { get; }

        public CustomerMemento(Customer customer)
        {
            Name = customer.Name;
            Address = customer.Address;
            City = customer.City;
            StateProvince = customer.StateProvince;
            PostalCode = customer.PostalCode;
        }
    }
}