using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Geometry;
using Algorithms;
using Interfaces;
using DTO;
using helpers = RectangleFactoryAPI.Helpers;
using db = Storage.ShapeStorage;

namespace RectangleFactoryAPI.Controllers
{
    [RoutePrefix("api/RectangleFactory")]
    public class RectangleFactoryController : BaseController
    {
        public RectangleFactoryController()
        {

        }

        #region [GET]

        /// <summary>
        /// Return the most recently generated result from the api/RectangleFactory/GenerateRectangles endpint
        /// </summary>
        /// <returns></returns>
        [Route("FactoryOutput/Current")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                MyRectangleAlgorithm rectangleAlgorithm = (MyRectangleAlgorithm)db.GetAlgorithm(null);

                return Ok(new
                {
                    Input = rectangleAlgorithm?.dataset,
                    Output = rectangleAlgorithm?.output
                });
            }
            catch (Exception ex)
            {
                return base.GenerateErrorResponse(ex);
            }
        }

        /// <summary>
        /// Search for and return a generated result from the api/RectangleFactory/GenerateRectangles endpint
        /// </summary>
        /// <returns></returns>
        [Route("FactoryOutput/RectangleCreationNumber/{rectangleCreationNumber}/Search")]
        [HttpGet]
        public async Task<IHttpActionResult> GetWithRectangleCreationNumnber([FromUri]int rectangleCreationNumber)
        {
            try
            {
                MyRectangleAlgorithm rectangleAlgorithm = (MyRectangleAlgorithm)db.GetAlgorithm(rectangleCreationNumber);

                return Ok(new
                {
                    Input = rectangleAlgorithm?.dataset,
                    Output = rectangleAlgorithm?.output
                });
            }
            catch (Exception ex)
            {
                return base.GenerateErrorResponse(ex);
            }
        }

        #endregion [GET]

        #region [POST]

        /// <summary>
        /// Call to generate rectangles.
        /// Return operation result status
        /// </summary>
        /// <returns></returns>
        [Route("GenerateRectangles")]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]MyRectangleAlgorithmInput input)
        {
            try
            {
                helpers.InputValidationHelper.validateMyRectangleAlgorithmInput(input);

                MyRectangleAlgorithm rectangleAlgorithm = new MyRectangleAlgorithm();

                rectangleAlgorithm.dataset = rectangleAlgorithm.generateRandomDataset(new Random(), helpers.ConfigHelper<int>.getValue("MaxRectangleDimensionLimit"), input.rectangleCreationNumber);

                rectangleAlgorithm.executeAlgorithm();

                db.StoreAlgorithm(input.rectangleCreationNumber, rectangleAlgorithm);

                return Ok(new
                {
                    Input = rectangleAlgorithm.dataset,
                    Output = rectangleAlgorithm.output,
                });
            }
            catch (Exception ex)
            {
                return base.GenerateErrorResponse(ex);
            }
        }

        #endregion [POST]
    }
}
