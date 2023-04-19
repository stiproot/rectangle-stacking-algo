using System;
using Interfaces;
using Geometry;
using System.Collections.Generic;
using System.Linq;
using Decorators;

namespace Algorithms
{
    public class MyRectangleAlgorithm : IMyRectangleAlgorithm
    {
        public IEnumerable<IShape> dataset { get; set; }
        public IEnumerable<IShape> output { get; set; }

        public IEnumerable<IShape> generateRandomDataset(Random random, int randomLimit, int n)
        {
            try
            {
                int randomNumberWithinRange(int min, int max)
                {
                    return random.Next(min, max);
                }

                List<Rectangle> data = new List<Rectangle>();

                for (int i = 0; i < n; i++)
                {
                    Rectangle r = new Rectangle(data.Count == 0 ? 0 : data[data.Count - 1].X + data[data.Count - 1].Width, 0, randomNumberWithinRange(1, randomLimit), randomNumberWithinRange(1, randomLimit));

                    data.Add(r);
                }

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void executeAlgorithm()
        {
            try
            {
                if (this.dataset == null)
                {
                    throw new InvalidOperationException("Dataset not set");
                }

                //instantiate output list
                this.output = new List<Rectangle>();

                List<RectangleDecorator> workingList = new List<RectangleDecorator>();

                for (int i = 0; i < this.dataset.Count(); i++)
                {
                    RectangleDecorator decorator = new RectangleDecorator()
                    {
                        index = i,
                        rectangle = ((List<Rectangle>)this.dataset)[i],
                        previous = null,
                        next = null
                    };

                    workingList.Add(decorator);

                    //i = index of newly added entry
                    if (i - 1 >= 0)
                    {
                        //build linked list to assist with traversal
                        workingList[i - 1].next = workingList[i];
                        workingList[i].previous = workingList[i - 1];
                    }
                }

                while (workingList.Any(r => r.isProcessed == false))
                {
                    //STEP 1: Find our subject for this iteration, an unprocessed rectangle with minimum height
                    int minHeight = workingList
                                        .Where(r => r.isProcessed == false)
                                        .Min(r => r.rectangle.Height);

                    //FirstOrDefault will handle the case of rectangles with the same height as they are ordered by index
                    RectangleDecorator subject = workingList
                                            .Where(r => r.rectangle.Height == minHeight && r.isProcessed == false)
                                            .FirstOrDefault();

                    //STEP 2: Find all rectangles included in disection of subjects height
                    List<RectangleDecorator> disectables = new List<RectangleDecorator>();

                    workingList.ForEach(r =>
                    {
                        //A retangle will be included in the formation of the new rectangle only if it meets the criteria:
                        //A line, on or through, rectangles inbetween (if any) exists that connects the subjects height to the rectangle being compared
                        //ie. if rectangle falls to the left of the subject. All rectangles to the left of the subject, inbetween subject and compared rectangle get checked

                        if (subject.noSpaceBetween(r))
                        {
                            disectables.Add(r);
                        }
                    });

                    //new rectangle co-ordinates and dimensions:
                    //x co-ordinate will be the x co-ordinate of the left most rectangle
                    int x = disectables.FirstOrDefault().X;
                    //width: sum of widths of all rectangles
                    int w = disectables.Sum(d => d.Width);
                    //y co-ordinate: y co-ord of subject + sum of heights of all newly built rectangles that are below this new rectangle 
                    int y = subject.rectangle.Y + this.output.Where(r => r.X <= x && r.X + r.Width >= x + w).Sum(r => r.Height);
                    //height: top of subject - y co-ord of new rectangle
                    int h = (subject.rectangle.Y + subject.rectangle.Height) - y;

                    Rectangle newRectangle = new Rectangle(x, y, w, h);

                    ((List<Rectangle>)this.output).Add(newRectangle);

                    subject.isProcessed = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MyRectangleAlgorithm()
        {

        }

        public MyRectangleAlgorithm(IEnumerable<IShape> input)
        {
            this.dataset = input;
        }
    }
}
