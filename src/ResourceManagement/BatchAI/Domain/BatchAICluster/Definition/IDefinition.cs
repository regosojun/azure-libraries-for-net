// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition
{
    using Microsoft.Azure.Management.BatchAI.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition;

    public interface IWithVMPriority 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate WithLowPriority();
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster>,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithUserCredentials,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithVMPriority,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithSetupTask,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithMountVolumes,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// Defines the volumes to mount on the cluster.
    /// </summary>
    public interface IWithMountVolumes
    {
        /// <summary>
        /// Begins the definition of Azure file share reference to be mounted on each cluster node.
        /// </summary>
        /// <return>The first stage of file share reference definition.</return>
        AzureFileShare.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate> DefineAzureFileShare();

        /// <summary>
        /// Begins the definition of Azure blob file system reference to be mounted on each cluster node.
        /// </summary>
        /// <return>The first stage of Azure blob file system reference definition.</return>
       AzureBlobFileSystem.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate> DefineAzureBlobFileSystem();

        /// <summary>
        /// Begins the definition of Azure file server reference.
        /// </summary>
        /// <return>The first stage of file server reference definition.</return>
        FileServer.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate> DefineFileServer();

        /// <summary>
        /// Specifies the details of the file system to mount on the compute cluster nodes.
        /// </summary>
        /// <param name="mountCommand">Command used to mount the unmanaged file system.</param>
        /// <param name="relativeMountPath">The relative path on the compute cluster node where the file system will be mounted.</param>
        /// <return>The next stage of Batch AI cluster definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate WithUnmanagedFileSystem(string mountCommand, string relativeMountPath);
    }

    /// <summary>
    /// Specifies the credentials to use for authentication on each of the nodes of a cluster.
    /// </summary>
    public interface IWithUserCredentials 
    {
        /// <param name="sshPublicKey">SSH public keys used to authenticate with linux based VMs.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithScaleSettings WithSshPublicKey(string sshPublicKey);

        /// <param name="password">Admin user password (linux only).</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithScaleSettings WithPassword(string password);
    }

    /// <summary>
    /// Specifies a setup task which can be used to customize the compute nodes
    /// of the cluster. The task runs everytime a VM is rebooted. For
    /// that reason the task code needs to be idempotent. Generally it is used
    /// to either download static data that is required for all jobs that run on
    /// the cluster VMs or to download/install software.
    /// NOTE: The volumes specified in mountVolumes are mounted first and then the setupTask is run.
    /// Therefore the setup task can use local mountPaths in its execution.
    /// </summary>
    public interface IWithSetupTask
    {
        /// <summary>
        /// Begins the definition of setup task.
        /// </summary>
        /// <return>The first stage of the setup task definition.</return>
        NodeSetupTask.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate> DefineSetupTask();
    }

    /// <summary>
    /// The first stage of a Batch AI cluster definition.
    /// </summary>
    public interface IBlank  :  IDefinitionWithRegion<IWithGroup>
    {
    }

    /// <summary>
    /// Specifies the name of the administrator account that gets created on each of the nodes of a cluster.
    /// </summary>
    public interface IWithUserName 
    {
        /// <param name="userName">The name of the administrator account.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithUserCredentials WithUserName(string userName);
    }

    /// <summary>
    /// The stage of a Batch AI cluster definition allowing to specify virtual machine size. All virtual machines in a cluster are the same size.
    /// For information about available VM sizes for clusters using images from the Virtual
    /// Machines Marketplace (see Sizes for Virtual Machines (Linux) or Sizes for Virtual Machines (Windows). Batch AI service supports all Azure VM
    /// sizes except STANDARD_A0 and those with premium storage (STANDARD_GS, STANDARD_DS, and STANDARD_DSV2 series).
    /// </summary>
    public interface IWithVMSize 
    {
        /// <param name="vmSize">Virtual machine size.</param>
        /// <return>Next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithUserName WithVMSize(string vmSize);
    }

    /// <summary>
    /// Specifies scale settings for the cluster.
    /// </summary>
    public interface IWithScaleSettings 
    {
        /// <summary>
        /// If autoScale settings are specified, the system automatically scales the cluster up and down (within
        /// the supplied limits) based on the pending jobs on the cluster.
        /// </summary>
        /// <param name="minimumNodeCount">The minimum number of compute nodes the cluster can have.</param>
        /// <param name="maximumNodeCount">The maximum number of compute nodes the cluster can have.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate WithAutoScale(int minimumNodeCount, int maximumNodeCount);

        /// <summary>
        /// If autoScale settings are specified, the system automatically scales the cluster up and down (within
        /// the supplied limits) based on the pending jobs on the cluster.
        /// </summary>
        /// <param name="minimumNodeCount">The minimum number of compute nodes the cluster can have.</param>
        /// <param name="maximumNodeCount">The maximum number of compute nodes the cluster can have.</param>
        /// <param name="initialNodeCount">
        /// The number of compute nodes to allocate on cluster creation.
        /// Note that this value is used only during cluster creation.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate WithAutoScale(int minimumNodeCount, int maximumNodeCount, int initialNodeCount);

        /// <summary>
        /// Specifies that cluster should be scaled by manual settings.
        /// </summary>
        /// <param name="targetNodeCount">The desired number of compute nodes in the Cluster.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate WithManualScale(int targetNodeCount);

        /// <summary>
        /// Specifies that cluster should be scaled by manual settings.
        /// </summary>
        /// <param name="targetNodeCount">The desired number of compute nodes in the Cluster.</param>
        /// <param name="deallocationOption">Determines what to do with the job(s) running on compute node if the cluster size is decreasing. The default value is requeue.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate WithManualScale(int targetNodeCount, DeallocationOption deallocationOption);
    }

    /// <summary>
    /// The entirety of a Batch AI cluster definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IBlank,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithGroup,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithVMSize,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithUserName,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithUserCredentials,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithScaleSettings,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of a Batch AI cluster definition allowing the resource group to be specified.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithVMSize>
    {
    }
}