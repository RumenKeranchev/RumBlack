using System;
using System.Linq;
using System.Reflection;

namespace RB.Common
{
	public static class Validator<T>
	{
		public static bool Validate( T model )
		{
			var properties = model.GetType().GetProperties();

			var propClass = properties
				.Where( p =>
				p.PropertyType != typeof( Int32 ) &&
				p.PropertyType != typeof( decimal ) &&
				p.PropertyType != typeof( char ) &&
				p.PropertyType != typeof( string ) &&
				p.PropertyType != typeof( DateTime ) &
				p.PropertyType.BaseType != typeof( Enum ) )
				.ToList();

			if ( propClass.Any() )
			{
				foreach ( var prop in propClass )
				{
					var nestedClassName = prop.Name;

					var nestedClass = model.GetType().GetProperty( nestedClassName ).GetValue( model, null );

					var nestedClassProperties =
						model.GetType().GetProperty( nestedClassName ).GetValue( model, null ).GetType().GetProperties();

					if ( !ValidateByProps( nestedClass, nestedClassProperties ) ) return false;
				}
			}


			if ( !ValidateByType( model, properties ) ) return false;

			return true;
		}

		private static bool ValidateByProps( object obj, PropertyInfo[] properties )
		{
			foreach ( var property in properties )
			{
				var type = property.PropertyType;

				if ( type == typeof( Int32 ) )
				{
					var field = Convert.ToInt32( property.GetValue( obj ) );

					if ( field <= 0 )
					{
						return false;
					}
				}

				else if ( type == typeof( decimal ) )
				{
					var field = Convert.ToDecimal( property.GetValue( obj ) );

					if ( field <= 0 )
					{
						return false;
					}
				}

				else if ( type == typeof( char ) )
				{
					var field = Convert.ToChar( property.GetValue( obj ) );

					if ( !char.IsDigit( field ) && !char.IsLetter( field ) )
					{
						return false;
					}
				}

				else if ( type == typeof( string ) )
				{
					var field = Convert.ToString( property.GetValue( obj ) );

					if ( string.IsNullOrWhiteSpace( field ) )
					{
						return false;
					}
				}

				else if ( type == typeof( DateTime ) )
				{
					DateTime tmp;

					if ( !DateTime.TryParse( Convert.ToString( property.GetValue( obj ) ), out tmp ) )
					{
						return false;
					}
				}

				else if ( type.BaseType == typeof( Enum ) )
				{
					var field = Convert.ToInt32( property.GetValue( obj ) );

					if ( field <= 0 )
					{
						return false;
					}
				}
			}

			return true;
		}

		private static bool ValidateByType( T model, PropertyInfo[] properties )
		{
			foreach ( var property in properties )
			{
				var type = property.PropertyType;

				if ( type == typeof( Int32 ) )
				{
					var field = Convert.ToInt32( property.GetValue( model ) );

					if ( field <= 0 )
					{
						return false;
					}
				}

				else if ( type == typeof( decimal ) )
				{
					var field = Convert.ToDecimal( property.GetValue( model ) );

					if ( field <= 0 )
					{
						return false;
					}
				}

				else if ( type == typeof( char ) )
				{
					var field = Convert.ToChar( property.GetValue( model ) );

					if ( !char.IsDigit( field ) && !char.IsLetter( field ) )
					{
						return false;
					}
				}

				else if ( type == typeof( string ) )
				{
					var field = Convert.ToString( property.GetValue( model ) );

					if ( string.IsNullOrWhiteSpace( field ) )
					{
						return false;
					}
				}

				else if ( type == typeof( DateTime ) )
				{
					DateTime tmp;

					if ( !DateTime.TryParse( Convert.ToString( property.GetValue( model ) ), out tmp ) )
					{
						return false;
					}
				}

				else if ( type.BaseType == typeof( Enum ) )
				{
					var field = Convert.ToInt32( property.GetValue( model ) );

					if ( field <= 0 )
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}