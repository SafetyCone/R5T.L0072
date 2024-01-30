using System;
using System.Text.Json;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0072
{
    /// <summary>
    /// JSON operator built around System.Text.Json functionality.
    /// </summary>
    /// <remarks>
    /// JSON functionality in .NET was previously through the Json.NET third-party library.
    /// This was crazy, since the official ASP.NET Core framework actually depended on the third-party Json.NET library!
    /// As of .NET Core 3.0 (see <inheritdoc cref="Links.ForSysmteTextJsonFrameworkAvailability" path="/summary"/>),
    /// JSON functionality in .NET has been brought into the framework.
    /// </remarks>
    [FunctionalityMarker]
    public partial interface IJsonOperator : IFunctionalityMarker
    {
        public T Load_FromFile_Synchronous<T>(string jsonFilePath)
        {
            var jsonText = Instances.FileOperator.Read_Text_Synchronous(jsonFilePath);

            var output = JsonSerializer.Deserialize<T>(jsonText);
            return output;
        }

        public async Task<T> Load_FromFile<T>(string jsonFilePath)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Read(jsonFilePath);

            var output = await JsonSerializer.DeserializeAsync<T>(fileStream);
            return output;
        }

        public T Load_FromFile_Synchronous<T>(
            string jsonFilePath,
            string objectKey)
        {
            var jsonText = Instances.FileOperator.Read_Text_Synchronous(jsonFilePath);

            var rootElement = JsonSerializer.Deserialize<JsonElement>(jsonText);

            var keyedElement = rootElement.GetProperty(objectKey);

            var output = keyedElement.Deserialize<T>();
            return output;
        }
    }
}
