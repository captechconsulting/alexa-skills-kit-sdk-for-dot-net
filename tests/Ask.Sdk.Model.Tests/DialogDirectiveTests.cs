using Ask.Sdk.Model.Request;
using Ask.Sdk.Model.Response.Directive;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ask.Sdk.Model.Tests
{
    public class DialogDirectiveTests
    {
        [Fact]
        public void Create_Valid_DialogDelegateDirective()
        {
            var actual = new DelegateDirective { UpdatedIntent = GetUpdatedIntent() };

            Assert.True(Utility.CompareJson(actual, "DialogDelegate.json"));
        }

        [Fact]
        public void Create_Valid_DialogElicitSlotDirective()
        {
            var actual = new ElicitSlotDirective("ZodiacSign") { UpdatedIntent = GetUpdatedIntent() };

            Assert.True(Utility.CompareJson(actual, "DialogElicitSlot.json"));
        }

        [Fact]
        public void Create_Valid_DialogConfirmSlotDirective()
        {
            var actual = new ConfirmSlotDirective("Date") { UpdatedIntent = GetUpdatedIntent() };

            Assert.True(Utility.CompareJson(actual, "DialogConfirmSlot.json"));
        }

        [Fact]
        public void Create_Valid_DialogConfirmIntentDirective()
        {
            var actual = new ConfirmIntentDirective { UpdatedIntent = GetUpdatedIntent() };
            actual.UpdatedIntent.Slots["ZodiacSign"].ConfirmationStatus = IntentConfirmationStatus.Confirmed;

            Assert.True(Utility.CompareJson(actual, "DialogConfirmIntent.json"));
        }

        private Intent GetUpdatedIntent()
        {
            return new Intent
            {
                Name = "GetZodiacHoroscopeIntent",
                ConfirmationStatus = IntentConfirmationStatus.None,
                Slots = new System.Collections.Generic.Dictionary<string, Slot>{
                    {"ZodiacSign",new Slot{Name="ZodiacSign",Value="virgo"}},
                        {
                        "Date",
                        new Slot
                        {
                            Name ="Date",
                            Value ="2015-11-25",
                            ConfirmationStatus =IntentConfirmationStatus.Confirmed
                        }
                    }
                }
            };
        }
    }
}
