# Version history

## Version 3.2.0, released 2022-07-25

### New features

- Added container field to findings attributes ([commit e8abc9d](https://github.com/googleapis/google-cloud-dotnet/commit/e8abc9dbb4d34da3f91ddbdc45067c2f86e16d4d))
- Added kubernetes field to findings attribute. This field is populated only when the container is a kubernetes cluster explicitly ([commit e8abc9d](https://github.com/googleapis/google-cloud-dotnet/commit/e8abc9dbb4d34da3f91ddbdc45067c2f86e16d4d))

## Version 3.1.0, released 2022-07-11

### New features

- Added contacts field to findings attributes, specifying Essential Contacts defined at org, folder or project level within a GCP org ([commit 70ddfdb](https://github.com/googleapis/google-cloud-dotnet/commit/70ddfdbdb4f4f0e21e6ebf22ecbaad32820afaa3))
- Added process signature fields to the indicator attribute that helps surface multiple types of signature defined IOCs ([commit 70ddfdb](https://github.com/googleapis/google-cloud-dotnet/commit/70ddfdbdb4f4f0e21e6ebf22ecbaad32820afaa3))

## Version 3.0.0, released 2022-06-08

This is the first version of this package to depend on GAX v4.

There are some breaking changes, both in GAX v4 and in the generated
code. The changes that aren't specific to any given API are [described in the Google Cloud
documentation](https://cloud.google.com/dotnet/docs/reference/help/breaking-gax4).
We don't anticipate any changes to most customer code, but please [file a
GitHub issue](https://github.com/googleapis/google-cloud-dotnet/issues/new/choose)
if you run into problems.

The most important change in this release is the use of the Grpc.Net.Client package
for gRPC communication, instead of Grpc.Core. When using .NET Core 3.1 or .NET 5.0+
this should lead to a smaller installation footprint and greater compatibility (e.g.
with Apple M1 chips). Any significant change in a core component comes with the risk
of incompatibility, however - so again, please let us know if you encounter any
issues.

### New features

- Add compliances, processes and exfiltration fields to findings attributes. They contain compliance information about a security standard indicating unmet recommendations, represents operating system processes, and data exfiltration attempt of one or more source(s) to one or more target(s).  Source(s) represent the source of data that is exfiltrated, and Target(s) represents the destination the data was copied to ([commit f8ec4a3](https://github.com/googleapis/google-cloud-dotnet/commit/f8ec4a3919a59023d593c39ae68bf9b9bcb9abb7))

## Version 2.13.0, released 2022-04-26

### New features

- Add connection and description field to finding's list of attributes ([commit a6bcaf5](https://github.com/googleapis/google-cloud-dotnet/commit/a6bcaf53ae63e568318902b157607ef4061455e9))
- Add next_steps field to finding's list of attributes ([commit 8d16471](https://github.com/googleapis/google-cloud-dotnet/commit/8d16471a1bfc243c84e22e0b5206e7d96b4fe7d2))
- Add iam_binding field to findings attributes. It represents particular IAM bindings, which captures a member's role addition, removal, or state ([commit b341824](https://github.com/googleapis/google-cloud-dotnet/commit/b341824885e0f7f3900447ab66565f14d20d8505))

## Version 2.12.0, released 2022-03-14

### New features

- Add BigQuery export APIs that help you enable writing new/updated findings from  Security Command Center to a BigQuery table in near-real time. You can then integrate the data into existing workflows and create custom analyses. You can enable this feature at the organization, folder, and project levels to export findings based on your requirements ([commit 4a00750](https://github.com/googleapis/google-cloud-dotnet/commit/4a0075066682f949bf00a3f72a299cbe8a6f8cce))

### Documentation improvements

- Update documentation for the Finding resource field "project_display_name" ([commit 09ff129](https://github.com/googleapis/google-cloud-dotnet/commit/09ff12926fd330d48048fbdaa58a08a3099f8da3))
- Update documentation for the Mute fields on Findings ([commit 09ff129](https://github.com/googleapis/google-cloud-dotnet/commit/09ff12926fd330d48048fbdaa58a08a3099f8da3))

## Version 2.11.0, released 2022-02-07

### New features

- Release the access field in the v1 finding proto, which represents an access event tied to the finding ([commit 7013d13](https://github.com/googleapis/google-cloud-dotnet/commit/7013d136ade920bdd69f1ad05213441ca2bc3810))

### Documentation improvements

- Added more clarification around what event_time means on a v1 finding ([commit 7013d13](https://github.com/googleapis/google-cloud-dotnet/commit/7013d136ade920bdd69f1ad05213441ca2bc3810))

## Version 2.10.0, released 2021-12-07

- [Commit 1cda659](https://github.com/googleapis/google-cloud-dotnet/commit/1cda659): feat: Added a new API method UpdateExternalSystem, which enables updating a finding w/ external system metadata. External systems are a child resource under finding, and are housed on the finding itself, and can also be filtered on in Notifications, the ListFindings and GroupFindings API

## Version 2.9.0, released 2021-11-18

- [Commit 7408292](https://github.com/googleapis/google-cloud-dotnet/commit/7408292): docs: fix docstring formatting
- [Commit 15d6b9a](https://github.com/googleapis/google-cloud-dotnet/commit/15d6b9a): feat: Added mute related APIs, proto messages and fields

## Version 2.8.0, released 2021-11-10

- [Commit 9292121](https://github.com/googleapis/google-cloud-dotnet/commit/9292121): feat: Added resource type and display_name field to the FindingResult, and supported them in the filter for ListFindings and GroupFindings. Also added display_name to the resource which is surfaced in NotificationMessage

## Version 2.7.0, released 2021-10-12

- [Commit e1080c9](https://github.com/googleapis/google-cloud-dotnet/commit/e1080c9):
  - feat: Added vulnerability field to the finding
  - feat: Added type field to the resource which is surfaced in NotificationMessage

## Version 2.6.0, released 2021-09-01

- [Commit ac367e2](https://github.com/googleapis/google-cloud-dotnet/commit/ac367e2): feat: Regenerate all APIs to support self-signed JWTs

## Version 2.5.0, released 2021-08-10

- [Commit f8b1856](https://github.com/googleapis/google-cloud-dotnet/commit/f8b1856):
  - feat: add finding_class and indicator fields in Finding

## Version 2.4.0, released 2021-06-22

- [Commit 16f75f9](https://github.com/googleapis/google-cloud-dotnet/commit/16f75f9): docs: update currently supported Finding filter fields.

## Version 2.3.0, released 2021-05-26

- [Commit 6b46c80](https://github.com/googleapis/google-cloud-dotnet/commit/6b46c80): feat: add canonical_name and folder fields

## Version 2.2.0, released 2021-02-08

- [Commit d6c34ac](https://github.com/googleapis/google-cloud-dotnet/commit/d6c34ac):
  - feat: added field severity to findings in v1 API
  - Clients will now see a new field, severity, on findings. They will also be able to filter and group by severity on ListFinding and GroupFinding API calls.

## Version 2.1.0, released 2020-11-10

- [Commit 0790924](https://github.com/googleapis/google-cloud-dotnet/commit/0790924): fix: Add gRPC compatibility constructors
- [Commit 0ca05f5](https://github.com/googleapis/google-cloud-dotnet/commit/0ca05f5): chore: Regenerate all APIs using protoc 3.13 and Grpc.Tools 2.31
- [Commit 3cc0bc8](https://github.com/googleapis/google-cloud-dotnet/commit/3cc0bc8): docs: Clarified that event_time can also be considered as the "update time" for a Finding. It also captures when a Finding was updated. The previous wording could've been interpreted as only the creation time.
- [Commit ccb9c33](https://github.com/googleapis/google-cloud-dotnet/commit/ccb9c33): fix: correct securitycenter grpc_service_configs
- [Commit 6bde7a3](https://github.com/googleapis/google-cloud-dotnet/commit/6bde7a3): docs: Regenerate all APIs with service comments in client documentation
- [Commit f83bdf1](https://github.com/googleapis/google-cloud-dotnet/commit/f83bdf1): fix: Apply timeouts to RPCs without retry
- [Commit d545bad](https://github.com/googleapis/google-cloud-dotnet/commit/d545bad): Specify allowed fields for UpdateNotificationConfig
- [Commit 4c52b95](https://github.com/googleapis/google-cloud-dotnet/commit/4c52b95): feat: Add Resource to the v1 NotificationMessage, which contains resource-related fields associated to the Finding notification. docs: Adjusted wording from Cloud SCC to Security Command Center, and updated filtering docs for List APIs.
- [Commit 947a573](https://github.com/googleapis/google-cloud-dotnet/commit/947a573): docs: Regenerate all clients with more explicit documentation

## Version 2.0.0, released 2020-03-19

No API surface changes compared with 2.0.0-beta02, just dependency
and implementation changes.

## Version 2.0.0-beta02, released 2020-03-12

- [Commit 8da93ef](https://github.com/googleapis/google-cloud-dotnet/commit/8da93ef): Adds support for notifications.
- [Commit 11173de](https://github.com/googleapis/google-cloud-dotnet/commit/11173de): Amended retry configuration

## Version 2.0.0-beta01, released 2020-02-18

This is the first prerelease targeting GAX v3. Please see the [breaking changes
guide](https://cloud.google.com/dotnet/docs/reference/help/breaking-gax2)
for details of changes to both GAX and code generation.

## Version 1.1.0, released 2019-12-10

- [Commit 50658e2](https://github.com/googleapis/google-cloud-dotnet/commit/50658e2): Add format methods to all resource name types

## Version 1.0.0, released 2019-07-10

Initial GA release.
