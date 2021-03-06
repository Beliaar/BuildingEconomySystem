﻿using Xenko.Engine;

namespace BuildingEconomy.Components
{
    /// <inheritdoc />
    /// <summary>
    ///     Working data of a building.
    /// </summary>
    public class Building : EntityComponent
    {
        /// <summary>
        ///     The name of the building.
        /// </summary>
        public string Name { get; set; }
    }
}
