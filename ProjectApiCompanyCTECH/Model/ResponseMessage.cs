namespace ProjectApiCompanyCTECH.Model
{
    public static class EmployeeResponse
    {
        public const string FullnameEmpty = "Fullname Empty";
        public const string FullnameEmptyMsg = "Fullname cannot be blank.";

        public const string EmailEmpty = "Email Empty";
        public const string EmailEmptyMsg = "Email cannot be blank.";

        public const string PhoneNumberEmpty = "PhoneNumber Empty";
        public const string PhoneNumberEmptyMsg = "PhoneNumber cannot be blank.";

        public const string ImageEmpty = "Image Empty";
        public const string ImageEmptyMsg = "Image cannot be blank.";

        public const string BiographyEmpty = "Biography Empty";
        public const string BiographyEmptyMsg = "Biography cannot be blank.";

        public const string EmployeeNotExist = "Employee Not Exist";
        public const string EmployeeNotExistMsg = "Employee not exist.";

    }
    public static class SystemResponse
    {
        public const string SystemError = "SystemError";
        public const string SystemErrorMsg = "An error occured.";

        public const string Success = "success";
        public const string SuccessMsg = "success.";

        public const string NotFound = "NotFound";
        public const string NotFoundMsg = "resource not found.";
    }
}
