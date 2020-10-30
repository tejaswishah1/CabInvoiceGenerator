using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceTestClass
{
    /// <summary>
    /// Class for test cases
    /// </summary>
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;

        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// Test Case to return Total Fare
        /// </summary>
        [Test]
        public void GIVEN_DISTANCE_AND_TIME_SHOULD_RETURN_TOTAL_FARE()
        {
            //Creating Instance of invoice Generator:
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            //Calculation of fare:
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25.0;

            Assert.AreEqual(expected, fare);
        }
        /// <summary>
        /// Given invalid ride type, should throw exception:
        /// </summary>
        [Test]

        public void GIVEN_INVALID_RIDE_TYPE_SHOULD_THROW_EXCEPTION()
        {
            //Creating Instance of invoice Generator:
            invoiceGenerator = new InvoiceGenerator();
            double distance = 2.0;
            int time = 5;

            ////Ride type not mentioned, Exception:
            string expected = "Inavlid Ride Type";
            try
            {
                //Calculate Ride Fare:
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException Exception)
            {
                //Asserting values:
                Assert.AreEqual(expected, Exception);
            }
        }
        /// <summary>
        /// Given invalid distance, should throw exception:
        /// </summary>
        [Test]

        public void GIVEN_INVALID_DISTANCE_SHOULD_THROW_EXCEPTION()
        {
            //Creating Instance of invoice Generator:
            invoiceGenerator = new InvoiceGenerator();
            double distance = -2.0; //Distance less than 0
            int time = 5;

            ////Ride type not mentioned, Exception:
            string expected = "Invalid Distance";
            try
            {
                //Calculate Ride Fare:
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException Exception)
            {
                //Asserting values:
                Assert.AreEqual(expected, Exception);
            }
        }
        /// <summary>
        /// Given invalid time, should throw exception:
        /// </summary>
        [Test]

        public void GIVEN_INVALID_TIME_SHOULD_THROW_EXCEPTION()
        {
            //Creating Instance of invoice Generator:
            invoiceGenerator = new InvoiceGenerator();
            double distance = 2.0;
            int time = -5; //Time less than 0

            ////Ride type not mentioned, Exception:
            string expected = "Invalid Time";
            try
            {
                //Calculate Ride Fare:
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException Exception)
            {
                //Asserting values:
                Assert.AreEqual(expected, Exception);
            }
        }
        /// <summary>
        /// Test case to check fare for multiple rides:
        /// </summary>
        [Test]

        public void GIVEN_MULTIPLE_RIDES_SHOULD_RETURN_TOTAL_FARE()
        {
            //Creating invoice of Invoice Generator:
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1)};

            //Calculating fare:
            InvoiceSummary actualFare = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedFare = new InvoiceSummary(2, 30.0); //2: Total rides, 30.0: Total fare

            //Assert vales:
            Assert.AreEqual(expectedFare, actualFare);
        }
        /// <summary>
        /// Test method to check invoice summary of particular user.
        /// </summary>
        [Test]
        public void GIVEN_USER_ID_SHOULD_RETURN_INVOICE_SUMMARY()
        {
            //Creating invoice of Invoice Generator:
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            //Declaring UserID
            string userID = "Tejas";
            Ride[] rides = { new Ride(25.12, 40), new Ride(12.39, 25) };

            //Add rides for user ID:
            invoiceGenerator.AddRides(userID, rides);

            //Calculating fare
            InvoiceSummary invoiceSummary = invoiceGenerator.GetInvoiceSummary(userID);
            InvoiceSummary summary = new InvoiceSummary(2, 440.1);

            //Assert values:
            Assert.AreEqual(summary, invoiceSummary);
        }
        /// <summary>
        /// Test method to check invoice summary of particular user.
        /// </summary>
        [Test]
        public void GIVEN_USER_ID_SHOULD_RETURN_INVOICE_SUMMAR()
        {
            //Creating invoice of Invoice Generator:
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            //Declaring UserID
            string userID = "Tejas";
            Ride[] rides = {  };

            //Add rides for user ID:
            invoiceGenerator.AddRides(userID, rides);
            string expected = "Rides Are Null";
            try
            {
                //Calculate Ride Fare:
                InvoiceSummary actualFare = invoiceGenerator.CalculateFare(rides);
            }
            catch (CabInvoiceException Exception)
            {
                //Asserting values:
                Assert.AreEqual(expected, Exception);
            }

            
        }





    }
}