﻿namespace CSharpLabs;
/*
[Simple Math Expression Evaluator]
Ask the user to enter math expression
Evaluate the expression & print the result
*/
public class App
{
  public static void Run()
  {
    while (true)
    {
      Console.Write("Please, Enter math expression: ");
      var input = Console.ReadLine();
      var exp = ExpressionParser.Parse(input);
      Console.WriteLine($"Left side = {exp.LeftSideOperand}");
      Console.WriteLine($"Right side = {exp.RightSideOperand}");
      Console.WriteLine($"Operation = {exp.Operation}");
      double result = EvaulateExpression(exp);
      Console.WriteLine($"{input} = {result}");
    }
  }
  public static double EvaulateExpression(MathExpression expr)
  {
    switch (expr.Operation)
    {
      case MathOperation.Addition:
        return expr.LeftSideOperand + expr.RightSideOperand;
      case MathOperation.Subtraction:
        return expr.LeftSideOperand + expr.RightSideOperand;
      case MathOperation.Multiplication:
        return expr.LeftSideOperand * expr.RightSideOperand;
      case MathOperation.Division:
        return expr.LeftSideOperand / expr.RightSideOperand;
      case MathOperation.Power:
        return Math.Pow(expr.LeftSideOperand, expr.RightSideOperand);
      case MathOperation.Modulus:
        return expr.RightSideOperand % expr.RightSideOperand;
      case MathOperation.Sin:
        return Math.Sin(expr.LeftSideOperand);
      case MathOperation.Cos:
        return Math.Cos(expr.LeftSideOperand);
      case MathOperation.Tan:
        return Math.Tan(expr.LeftSideOperand);
      default:
        return 0;
    }
  }
}
