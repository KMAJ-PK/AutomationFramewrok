namespace WebFramework
{
    public class ClientSideScripts
    {
        public const string LoseFocus = @"arguments[0].blur();";

        public static string DeleteTabSet(string tabSetName)
        {
            return string.Format("var callback = arguments[arguments.length - 1]; " +
                "angular.element(document.querySelector('body')).injector().get('customControlService').delete('{0}');" +
                "callback();", tabSetName);
        }
    }
}
