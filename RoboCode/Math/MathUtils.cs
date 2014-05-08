namespace arusslabs
{
	/// <summary>
	/// Contains commonly used precalculated values and mathematical operations.
	/// </summary>
	public static class MathUtils
	{
		/// <summary>
		/// Represents the log base ten of e(0.4342945f).
		/// </summary>
		public const double Log10E = 0.4342945d;

		/// <summary>
		/// Represents the log base two of e(1.442695f).
		/// </summary>
		public const double Log2E = 1.442695d;

		/// <summary>
		/// Represents the value of pi divided by two(1.57079637).
		/// </summary>
		public const double PiOver2 = System.Math.PI / 2.0;

		/// <summary>
		/// Represents the value of pi divided by four(0.7853982).
		/// </summary>
		public const double PiOver4 = System.Math.PI / 4.0;

		/// <summary>
		/// Represents the value of pi times two(6.28318548).
		/// </summary>
		public const double TwoPi = System.Math.PI * 2.0;

		/// <summary>
		/// Returns the Cartesian coordinate for one axis of a point that is defined by a given triangle and two normalized barycentric (areal) coordinates.
		/// </summary>
		/// <param name="value1">The coordinate on one axis of vertex 1 of the defining triangle.</param>
		/// <param name="value2">The coordinate on the same axis of vertex 2 of the defining triangle.</param>
		/// <param name="value3">The coordinate on the same axis of vertex 3 of the defining triangle.</param>
		/// <param name="amount1">The normalized barycentric (areal) coordinate b2, equal to the weighting factor for vertex 2, the coordinate of which is specified in value2.</param>
		/// <param name="amount2">The normalized barycentric (areal) coordinate b3, equal to the weighting factor for vertex 3, the coordinate of which is specified in value3.</param>
		/// <returns>Cartesian coordinate of the specified point with respect to the axis being used.</returns>
		public static double Barycentric(double value1, double value2, double value3, double amount1, double amount2)
		{
			return value1 + (value2 - value1) * amount1 + (value3 - value1) * amount2;
		}

		/// <summary>
		/// Performs a Catmull-Rom interpolation using the specified positions.
		/// </summary>
		/// <param name="value1">The first position in the interpolation.</param>
		/// <param name="value2">The second position in the interpolation.</param>
		/// <param name="value3">The third position in the interpolation.</param>
		/// <param name="value4">The fourth position in the interpolation.</param>
		/// <param name="amount">Weighting factor.</param>
		/// <returns>A position that is the result of the Catmull-Rom interpolation.</returns>
		public static double CatmullRom(double value1, double value2, double value3, double value4, double amount)
		{
			// Using formula from http://www.mvps.org/directx/articles/catmull/
			// Internally using doubles not to lose precission
			var amountSquared = amount * amount;
			var amountCubed = amountSquared * amount;
			return (0.5 * (2.0 * value2 +
			               (value3 - value1) * amount +
			               (2.0 * value1 - 5.0 * value2 + 4.0 * value3 - value4) * amountSquared +
			               (3.0 * value2 - value1 - 3.0 * value3 + value4) * amountCubed));
		}

		/// <summary>
		/// Restricts a value to be within a specified range.
		/// </summary>
		/// <param name="value">The value to clamp.</param>
		/// <param name="min">The minimum value. If <c>value</c> is less than <c>min</c>, <c>min</c> will be returned.</param>
		/// <param name="max">The maximum value. If <c>value</c> is greater than <c>max</c>, <c>max</c> will be returned.</param>
		/// <returns>The clamped value.</returns>
		public static double Clamp(double value, double min, double max)
		{
			// First we check to see if we're greater than the max
			value = (value > max) ? max : value;

			// Then we check to see if we're less than the min.
			value = (value < min) ? min : value;

			// There's no check to see if min > max.
			return value;
		}

		/// <summary>
		/// Restricts a value to be within a specified range.
		/// </summary>
		/// <param name="value">The value to clamp.</param>
		/// <param name="min">The minimum value. If <c>value</c> is less than <c>min</c>, <c>min</c> will be returned.</param>
		/// <param name="max">The maximum value. If <c>value</c> is greater than <c>max</c>, <c>max</c> will be returned.</param>
		/// <returns>The clamped value.</returns>
		public static int Clamp(int value, int min, int max)
		{
			value = (value > max) ? max : value;
			value = (value < min) ? min : value;
			return value;
		}

		/// <summary>
		/// Calculates the absolute value of the difference of two values.
		/// </summary>
		/// <param name="value1">Source value.</param>
		/// <param name="value2">Source value.</param>
		/// <returns>Distance between the two values.</returns>
		public static double Distance(double value1, double value2)
		{
			return System.Math.Abs(value1 - value2);
		}

		/// <summary> 
		/// Performs a Hermite spline interpolation.
		/// </summary>
		/// <param name="value1">Source position.</param>
		/// <param name="tangent1">Source tangent.</param>
		/// <param name="value2">Source position.</param>
		/// <param name="tangent2">Source tangent.</param>
		/// <param name="amount">Weighting factor.</param>
		/// <returns>The result of the Hermite spline interpolation.</returns>
		public static double Hermite(double value1, double tangent1, double value2, double tangent2, double amount)
		{
			// All transformed to double not to lose precission
			// Otherwise, for high numbers of param:amount the result is NaN instead of Infinity
			double v1 = value1, v2 = value2, t1 = tangent1, t2 = tangent2, s = amount, result;
			double sCubed = s * s * s;
			double sSquared = s * s;

			if (amount == 0d)
				result = value1;
			else if (amount == 1d)
				result = value2;
			else
				result = (2 * v1 - 2 * v2 + t2 + t1) * sCubed +
				         (3 * v2 - 3 * v1 - 2 * t1 - t2) * sSquared +
				         t1 * s +
				         v1;
			return result;
		}
        
		/// <summary>
		/// Linearly interpolates between two values.
		/// </summary>
		/// <param name="value1">Source value.</param>
		/// <param name="value2">Source value.</param>
		/// <param name="amount">Value between 0 and 1 indicating the weight of value2.</param>
		/// <returns>Interpolated value.</returns> 
		/// <remarks>This method performs the linear interpolation based on the following formula.
		/// <c>value1 + (value2 - value1) * amount</c>
		/// Passing amount a value of 0 will cause value1 to be returned, a value of 1 will cause value2 to be returned.
		/// </remarks>
		public static double Lerp(double value1, double value2, double amount)
		{
			return value1 + (value2 - value1) * amount;
		}

		/// <summary>
		/// Returns the greater of two values.
		/// </summary>
		/// <param name="value1">Source value.</param>
		/// <param name="value2">Source value.</param>
		/// <returns>The greater value.</returns>
		public static double Max(double value1, double value2)
		{
			return System.Math.Max(value1, value2);
		}

		/// <summary>
		/// Returns the lesser of two values.
		/// </summary>
		/// <param name="value1">Source value.</param>
		/// <param name="value2">Source value.</param>
		/// <returns>The lesser value.</returns>
		public static double Min(double value1, double value2)
		{
			return System.Math.Min(value1, value2);
		}

		/// <summary>
		/// Interpolates between two values using a cubic equation.
		/// </summary>
		/// <param name="value1">Source value.</param>
		/// <param name="value2">Source value.</param>
		/// <param name="amount">Weighting value.</param>
		/// <returns>Interpolated value.</returns>
		public static double SmoothStep(double value1, double value2, double amount)
		{
			var result = Clamp(amount, 0d, 1d);
			result = Hermite(value1, 0d, value2, 0d, result);
			return result;
		}

		/// <summary>
		/// Converts radians to degrees.
		/// </summary>
		/// <param name="radians">The angle in radians.</param>
		/// <returns>The angle in degrees.</returns>
		/// <remarks>
		/// This method uses double precission internally,
		/// though it returns single double
		/// Factor = 180 / pi
		/// </remarks>
		public static double ToDegrees(double radians)
		{
			return (radians * 57.295779513082320876798154814105);
		}

		/// <summary>
		/// Converts degrees to radians.
		/// </summary>
		/// <param name="radians">The angle in degrees.</param>
		/// <returns>The angle in radians.</returns>
		/// <remarks>
		/// This method uses double precission internally,
		/// though it returns single double
		/// Factor = pi / 180
		/// </remarks>
		public static double ToRadians(double degrees)
		{
			return degrees * 0.017453292519943295769236907684886;
		}

		/// <summary>
		/// Reduces a given angle to a value between π and -π.
		/// </summary>
		/// <param name="angle">The angle to reduce, in radians.</param>
		/// <returns>The new angle, in radians.</returns>
		public static double WrapAngle(double angle)
		{
			angle = System.Math.IEEERemainder(angle, 6.2831854820251465);
			if (angle <= -3.14159274f)
			{
				angle += 6.28318548f;
			}
			else
			{
				if (angle > 3.14159274f)
				{
					angle -= 6.28318548f;
				}
			}
			return angle;
		}

		/// <summary>
		/// Determines if value is powered by two.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <returns><c>true</c> if <c>value</c> is powered by two; otherwise <c>false</c>.</returns>
		public static bool IsPowerOfTwo(int value)
		{
			return (value > 0) && ((value & (value - 1)) == 0);
		}
	}
}