using System;

namespace DeviceAddressLambda {
    public static class Messages {
        public static string[] PERMISSIONS = { "read::alexa:device:all:address" };
        public static string ERROR = "Uh Oh. Looks like something went wrong.";
        public static string MISSING_PERMISSIONS = "Please enable Location permissions in the Amazon Alexa app.";
        public static string LOCATION_FAILURE = "There was an error with the Device Address API. Please try again.";
        public static string WELCOME = "Welcome to the Sample Device Address API Skill!  You can ask for the device address by saying what is my address.  What do you want to ask?";
        public static string HELP = "You can use this skill by asking something like: whats my address?";
    }

    public static class Intents {
        public static string DEVICE_ADDRESS = "DeviceAddressIntent";
    }
}