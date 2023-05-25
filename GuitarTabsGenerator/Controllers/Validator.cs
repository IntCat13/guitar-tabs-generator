// Guitar Tabs Generator
// Input validator
// Created by IntCat13 

using GuitarTabsGenerator.ViewModels;

namespace GuitarTabsGenerator.Controllers;

public static class Validator
{
    // Input validation method
    public static bool IsInputNotValid(MainViewModel model)
    {
        bool isInputNotValid = false;
        string errorMessage = "Input is not valid: ";

        if (string.IsNullOrEmpty(model.ApiKey))
        {
            isInputNotValid = true;
            errorMessage += "Api key is empty, ";
        }

        if (string.IsNullOrEmpty(model.Promt))
        {
            isInputNotValid = true;
            errorMessage += "Promt is empty, ";
        }

        if (isInputNotValid)
            UIController.SetStatus(model, errorMessage);

        return isInputNotValid;
    }
}