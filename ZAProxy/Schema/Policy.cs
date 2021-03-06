﻿namespace ZAProxy.Schema
{
    /// <summary>
    /// Describes a scan policy.
    /// </summary>
    public class Policy
    {
        /// <summary>
        /// Gets or sets the strength of attacks performed by scanners in this policy.
        /// </summary>
        public AttackStrength AttackStrength { get; set; }

        /// <summary>
        /// Gets or sets the threshold of alerts generated by scanners in this policy.
        /// </summary>
        public AlertThreshold AlertThreshold { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets whether the policy is enabled.
        /// </summary>
        public bool Enabled { get; set; }
    }
}
