using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ConsoleToWebAPI.Models
{
    public class CustomBinderCountryDetails : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var value = bindingContext.ValueProvider.GetValue(modelName);
            var result = value.FirstValue;

            if (!int.TryParse(result, out var id))
            {
                return Task.CompletedTask;
            }

            var model = new CountryModel()
            {
                ID = id,
                Area = 800,
                Name = "India",
                Population = 600
            };

            bindingContext.Result = ModelBindingResult.Success(model);

            return Task.CompletedTask;
        }
    }
}
