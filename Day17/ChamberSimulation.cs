namespace Day17;

public class ChamberSimulation
{
    public readonly Chamber _chamber;
    public readonly JetDirectionFactory _jetDirectionFactory;

    public ChamberSimulation(ShapeFactory shapeFactory, JetDirectionFactory jetDirectionFactory)
	{
        _chamber =  new Chamber(shapeFactory);
        _jetDirectionFactory = jetDirectionFactory;
	}

    public void DropRock()
    {
        _chamber.AddRock();

        while (true)
        {
            switch (_jetDirectionFactory.NextJetDirection())
            {
                case '<': _chamber.MoveLeftIfClear(); break;
                case '>': _chamber.MoveRightIfClear(); break;
                default: throw new InvalidOperationException();
            }

            if (!_chamber.TryMoveDown())
            {
                _chamber.RestShape();
                return;
            }
        }
    }

    public override string ToString() => _chamber.ToString();
}
