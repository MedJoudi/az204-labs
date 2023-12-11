// Import the Newtonsoft.Json library for JSON handling
#r "Newtonsoft.Json"

// Import necessary libraries for logging and JSON handling
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

// This function processes an incoming message from a queue.
// It takes a JSON object (order) as input, extracts certain fields from it, and writes those fields to a Table storage.
public static Person Run(JObject order, ILogger log)
{
    // Create a new Person object to represent a row in the Table Storage
    return new Person()
    { 
        // Set the PartitionKey to "Orders" (a common identifier for this type of data in Table Storage)
        PartitionKey = "Orders",
        
        // Set the RowKey to a new unique GUID (used to uniquely identify this row in Table Storage)
        RowKey = Guid.NewGuid().ToString(),
        
        // Extract the "Name" field from the input JSON and assign it to the Name property of the Person object
        Name = order["Name"].ToString(),
        
        // Extract the "MobileNumber" field from the input JSON and assign it to the MobileNumber property of the Person object
        MobileNumber = order["MobileNumber"].ToString()
    };  
}

// Define a class called Person to represent the data structure that will be written to Table Storage
public class Person
{
    // Define properties for the PartitionKey, RowKey, Name, and MobileNumber
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Name { get; set; }
    public string MobileNumber { get; set; }
}
