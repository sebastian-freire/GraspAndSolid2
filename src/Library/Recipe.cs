//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Text;

namespace Full_GRASP_And_SOLID.Library
{
    /*
    Segun el principio SRP una clase solo debe tener una unica razon para cambiar.
    Anteriormente esta clase tenia mas de una, una de ellas siendo si se queria cambiar el metodo de impresion y 
    la otra si se querian agregar atributos adicionales a las recetas.

    Con esto en mente se decide crear una clase ConsolePrinter. Esta clase sera la encargada de imprimir en consola.

    -------¿Pero como recibe el texto que tiene que imprimir?--------
    La clase recipe generara un stringBuilder con el texto que se desea imprimir mediante el metodo StringRecipe.
    Y en la clase ConsolePrinter hay un metodo Imprimir que recibe como parametro un stringBuilder y lo imprime en consola.

    De esta manera se pueden implementar varias formas de impresion utilizando el texto generado por el metodo
    StringRecipe.
    */
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public StringBuilder StringRecipe()
        {
            StringBuilder stringBuilder= new StringBuilder();
            stringBuilder.Append($"\nReceta de {this.FinalProduct.Description}:\n");
            foreach (Step step in this.steps)
            {
                stringBuilder.Append($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}\n");
            }
            return stringBuilder;
        }
    }
}