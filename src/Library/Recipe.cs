//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
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

        /* Patrón Expert: La clase Recipe tiene la responsabilidad de calcular el costo de producción
        porque es la que conoce los pasos de la receta, necesarios para calcular el costo
        
        Patrón SRP: La clase Recipe no debe tener más de una razón para cambiar. En este caso consideramos
        que se debe modificar si cambia la fórmula para calcular el costo total, pero no el costo de
        los insumos o el equipamiento. Por ejemplo, si para calcular el costo total se quiere tomar en 
        cuenta un costo de mano de obra, en base al tiempo que insume la receta entera, eso cambia el método
        en la clase Recipe, pero si se quiere agregar un costo fijo al cálculo del uso del equipamiento para
        cada paso, eso debería ser responsabilidad de otra clase, en este caso la clase Step*/
        public double GetProductionCost()
        {
            double insumos = 0;
            double equipamiento = 0;

            foreach (Step step in steps)
            {
                insumos += step.GetStepCost();
                equipamiento += step.GetEquipmentCost();
            }

            return insumos + equipamiento;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }
    }
}