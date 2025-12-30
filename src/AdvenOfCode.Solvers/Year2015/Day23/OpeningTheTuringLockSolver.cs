using System.Globalization;

namespace AdvenOfCode.Solvers.Year2015.Day23;

public sealed partial class OpeningTheTuringLockSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        Register registerA = new("a");
        Register registerB = new("b");
        RunProgram(registerA, registerB);
        return (long)registerB.Value;
    }

    private void RunProgram(Register registerA, Register registerB)
    {
        int instructionIndex = 0;
        while (instructionIndex < Input.Length)
        {
            ReadOnlySpan<char> instruction = Input[instructionIndex];
            Register register;
            ReadOnlySpan<char> jump;
            ReadOnlySpan<char> operation = instruction[0..3];
            switch (operation)
            {
                case "hlf":
                    register = PickRegister(registerA, registerB, instruction);
                    register.Half();
                    instructionIndex++;
                    break;
                case "tpl":
                    register = PickRegister(registerA, registerB, instruction);
                    register.Triple();
                    instructionIndex++;
                    break;
                case "inc":
                    register = PickRegister(registerA, registerB, instruction);
                    register.Increment();
                    instructionIndex++;
                    break;
                case "jmp":
                    jump = instruction[4..];
                    instructionIndex += int.Parse(jump, CultureInfo.InvariantCulture);
                    break;
                case "jie":
                    register = PickRegister(registerA, registerB, instruction);
                    if (register.IsEven())
                    {
                        jump = instruction[7..];
                        instructionIndex += int.Parse(jump, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        instructionIndex++;
                    }
                    break;
                case "jio":
                    register = PickRegister(registerA, registerB, instruction);
                    if (register.IsOne())
                    {
                        jump = instruction[7..];
                        instructionIndex += int.Parse(jump, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        instructionIndex++;
                    }
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }

    private static Register PickRegister(Register registerA, Register registerB, ReadOnlySpan<char> instruction)
    {
        return instruction[4] switch
        {
            'a' => registerA,
            'b' => registerB,
            _ => throw new InvalidOperationException()
        };
    }

    public override long SolvePart2()
    {
        Register registerA = new("a");
        registerA.Increment();
        Register registerB = new("b");
        RunProgram(registerA, registerB);
        return (long)registerB.Value;
    }
}

internal sealed record Register(string Name)
{
    public ulong Value { get; private set; }
    public void Half()
    {
        Value /= 2;
    }
    public void Triple()
    {
        Value *= 3;
    }

    public void Increment()
    {
        Value++;
    }

    public bool IsEven()
    {
        return Value % 2 == 0;
    }

    public bool IsOne()
    {
        return Value == 1;
    }
}