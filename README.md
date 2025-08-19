# Claude.Orchestrator

Multi-agent workflow orchestration and context management tool for the Claude Code ecosystem.

## Overview

Claude.Orchestrator is a .NET global tool that provides shared context management, workflow state persistence, and performance analytics for Claude Code's multi-agent environment. It enables seamless communication between agents, tracks complex multi-step operations, and provides comprehensive monitoring across the entire sub-agent ecosystem.

## Features

### 🔄 Shared Context Management (Issue #15)
- **Context Storage**: Persistent JSON-based context storage in `~/.claude/context/`
- **Context Types**: Support for task, error, performance, quality, configuration, and security contexts
- **Context Scopes**: Session-level, project-level, and global context isolation
- **Context Security**: Role-based access control and audit logging for sensitive data
- **Context Lifecycle**: Automatic cleanup of expired contexts with configurable retention

### 🎯 Workflow State Persistence (Issue #16)
- **Workflow Definition**: YAML-based workflow definition with steps, dependencies, and rollback procedures
- **State Persistence**: Persistent storage for workflow execution state and progress
- **Resume Capability**: Ability to resume interrupted workflows from last successful step
- **Rollback Support**: Automated rollback of failed workflows with cleanup procedures
- **Template System**: Pre-defined workflow templates for common development scenarios

### 📊 Performance Analytics (Issue #18)
- **Comprehensive Metrics**: Track agent performance, success rates, response times, and user satisfaction
- **Usage Analytics**: Monitor agent utilization patterns and workflow efficiency
- **Performance Dashboard**: Real-time performance monitoring with actionable insights
- **Quality Metrics**: Resolution accuracy, first-time resolution rates, and escalation tracking
- **Business Impact**: ROI analysis and productivity improvement measurement

## Installation

Install as a .NET global tool:

```bash
dotnet tool install --global Claude.Orchestrator
```

## Usage

### Context Management

```bash
# Create a new context
claude-orchestrator context create --type task --scope session --data '{"task_id": "feature-xyz", "status": "in_progress"}'

# List contexts
claude-orchestrator context list --type task --scope session

# Get specific context
claude-orchestrator context get <context-id>

# Update context
claude-orchestrator context update <context-id> --data '{"status": "completed"}'

# Search contexts
claude-orchestrator context search "feature implementation"

# Cleanup expired contexts
claude-orchestrator context cleanup --older-than 7d
```

### Workflow Management

```bash
# Create workflow from template
claude-orchestrator workflow create --template feature-development --config config.yaml

# List active workflows
claude-orchestrator workflow list --status running

# Check workflow status
claude-orchestrator workflow status <workflow-id>

# Resume interrupted workflow
claude-orchestrator workflow resume <workflow-id>

# Rollback failed workflow
claude-orchestrator workflow rollback <workflow-id> --to-step <step-id>
```

### Performance Analytics

```bash
# Show agent performance metrics
claude-orchestrator metrics show --agent software-engineer --timeframe 30d

# Compare agent performance
claude-orchestrator metrics compare --agents test-engineer,software-engineer

# View usage analytics
claude-orchestrator analytics usage --timeframe 7d

# Export performance data
claude-orchestrator metrics export --format csv --timeframe 30d
```

## Architecture

### Project Structure

```
Claude.Orchestrator/
├── Claude.Orchestrator.sln
├── Claude.Orchestrator.Console/          # Main console application
│   ├── Commands/                         # CLI command implementations
│   ├── Models/                          # Data models and DTOs
│   │   ├── Context/                     # Context management models
│   │   ├── Workflow/                    # Workflow state models
│   │   └── Analytics/                   # Performance metrics models
│   ├── Services/                        # Business logic services
│   └── Schemas/                         # JSON schema definitions
├── Claude.Orchestrator.Tests/            # Test project with Reqnroll BDD
│   ├── Features/                        # Gherkin BDD scenarios
│   └── StepDefinitions/                 # BDD step implementations
└── README.md
```

### Core Components

- **Context Service**: Manages shared context storage and lifecycle
- **Workflow Engine**: Orchestrates multi-step workflows with state persistence
- **Metrics Collector**: Tracks performance and usage analytics
- **Security Manager**: Handles access control and audit logging
- **CLI Commands**: System.CommandLine-based command interface

## Development

### Prerequisites

- .NET 9.0 SDK
- Visual Studio 2022 or VS Code

### Building

```bash
# Build the solution
dotnet build

# Run tests
dotnet test

# Pack as global tool
dotnet pack --configuration Release

# Install locally for testing
dotnet tool uninstall --global Claude.Orchestrator
dotnet tool install --global --add-source "./Claude.Orchestrator.Console/bin/Release" Claude.Orchestrator
```

### Testing

The project uses xUnit with Reqnroll BDD for comprehensive testing:

```bash
# Run all tests
dotnet test

# Run BDD scenarios only
dotnet test --filter "TestCategory=BDD"

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## Integration with Claude Code Ecosystem

Claude.Orchestrator is designed to integrate seamlessly with the existing Claude Code sub-agent ecosystem:

### Supported Agents
- **software-engineer**: Implementation and refactoring tasks
- **test-engineer**: Test-driven development and BDD scenarios
- **pr-manager**: Pull request lifecycle management
- **pipeline-monitor**: CI/CD workflow monitoring
- **test-failure-analyzer**: Multi-framework test failure analysis
- **infrastructure-troubleshooter**: System and container diagnostics
- **nuget-bcl-manager**: Package management and security scanning

### Context Flow Example
1. `test-engineer` creates failing test and stores results in shared context
2. `software-engineer` retrieves context, implements solution, updates context
3. `pr-manager` accesses context to create PR with comprehensive description
4. `pipeline-monitor` tracks CI/CD execution and updates workflow state
5. All metrics are automatically collected for performance analysis

## Configuration

Context and workflow data is stored in `~/.claude/` directory:

```
~/.claude/
├── context/                    # Shared context storage
│   ├── session/               # Session-scoped contexts
│   ├── project/               # Project-scoped contexts
│   └── global/                # Global contexts
├── workflows/                 # Workflow state persistence
│   ├── active/                # Currently running workflows
│   ├── completed/             # Completed workflow history
│   └── templates/             # Workflow templates
└── analytics/                 # Performance metrics and analytics
    ├── metrics/               # Agent performance data
    └── feedback/              # User feedback and satisfaction
```

## Security

- **Role-based Access Control**: Agents have specific permissions for context operations
- **Audit Logging**: Complete audit trail of all context and workflow operations
- **Data Encryption**: Optional encryption for sensitive context data
- **Scope Isolation**: Strict isolation between different context scopes

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes with tests
4. Ensure all tests pass
5. Submit a pull request

## License

This project is part of the CodexForge Tools ecosystem and follows the same licensing terms.

## Related Issues

- [Issue #15: Shared Context Mechanism](https://github.com/CodexForgeBR/MDA/issues/15)
- [Issue #16: Workflow State Persistence](https://github.com/CodexForgeBR/MDA/issues/16)  
- [Issue #18: Performance Analytics](https://github.com/CodexForgeBR/MDA/issues/18)