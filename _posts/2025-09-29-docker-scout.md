---
layout: post
title: "Como utilizar o docker scout para analisar imagens docker"
date:   2025-09-29
categories: [Docker, Desenvolvimento]
excerpt: "O <b>Docker Scout</b> é uma ferramenta poderosa que permite analisar imagens Docker para identificar vulnerabilidades, dependências desatualizadas e outras questões de segurança. Neste post, vamos explorar como utilizar o <b>Docker Scout</b> para melhorar a segurança e a eficiência das suas imagens Docker."
tags: [Docker, Desenvolvimento, Docker Scout, Segurança]
tagFile: [docker, desenvolvimento, docker-scout, seguranca]
parts: 
month: "Setembro"
year: "2025"
---
Para garantir a segurança das suas imagens Docker, é essencial utilizar ferramentas que possam analisar e identificar vulnerabilidades, fornecendo o *Software Bill of Materials (SBOM)* e uma lista de *Common Vulnerabilities and Exposures (CVEs)*.


O **Docker Scout**, foi desenvolvido pela **Docker Inc.**, podemos utilizá-lo tanto em tempo de desenvolvimento, como também associar aos processos de *CI/CD*, assim garantimos que não estamos utilizando imagens vulneráveis em produção.

Para o exemplo, vamos utilizar duas imagens do **nginx**, a primeira imagem é a versão `stable`, e a segunda é `stable-alpine`. A imagem `stable` é uma imagem mais completa, enquanto a `stable-alpine` é uma versão mais leve, baseada na distribuição **Alpine Linux**. Será que a imagem mais leve é a mais segura? Vamos descobrir!

{% include code-header.html %}
```bash
docker pull nginx:stable

docker pull nginx:stable-alpine
```

Agora vamos utilizar o **Docker Scout** para analisar as imagens e verificar as vulnerabilidades de cada uma. O comando abaixo irá analisar a imagem `nginx:stable` e fornecer um relatório detalhado sobre as vulnerabilidades encontradas.

{% include code-header.html %}
```bash
docker scout cves nginx:stable
```
{% include code-header.html %}
```markdown
    i New version 1.18.3 available (installed version is 1.17.0) at https://github.com/docker/scout-cli
    v SBOM of image already cached, 239 packages indexed
    x Detected 24 vulnerable packages with a total of 66 vulnerabilities


## Overview

                    │           Analyzed Image
────────────────────┼─────────────────────────────────────
  Target            │  nginx:stable 
    digest          │  2945a0bfa07b 
    platform        │ linux/amd64
    vulnerabilities │    0C     3H     2M    59L     2?   
    size            │ 72 MB
    packages        │ 239


## Packages and Vulnerabilities

   0C     1H     1M     1L  libxslt 1.1.35-1+deb12u2
pkg:deb/debian/libxslt@1.1.35-1%2Bdeb12u2?os_distro=bookworm&os_name=debian&os_version=12

    x HIGH CVE-2025-7425
      https://scout.docker.com/v/CVE-2025-7425
      Affected range : >=1.1.35-1+deb12u2
      Fixed version  : not fixed

    x MEDIUM CVE-2025-10911
      https://scout.docker.com/v/CVE-2025-10911
      Affected range : >=1.1.35-1+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2015-9019
      https://scout.docker.com/v/CVE-2015-9019
      Affected range : >=1.1.35-1+deb12u2
      Fixed version  : not fixed


   0C     1H     0M    14L     2?  tiff 4.5.0-6+deb12u2
pkg:deb/debian/tiff@4.5.0-6%2Bdeb12u2?os_distro=bookworm&os_name=debian&os_version=12

    x HIGH CVE-2025-9900
      https://scout.docker.com/v/CVE-2025-9900
      Affected range : >=4.5.0-6+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2025-9165
      https://scout.docker.com/v/CVE-2025-9165
      Affected range : >=4.5.0-6+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2025-8961
      https://scout.docker.com/v/CVE-2025-8961
      Affected range : >=4.5.0-6+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2025-8851
      https://scout.docker.com/v/CVE-2025-8851
      Affected range : >=4.5.0-6+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2025-8534
      https://scout.docker.com/v/CVE-2025-8534
      Affected range : >=4.5.0-6+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2025-8177
      https://scout.docker.com/v/CVE-2025-8177
      Affected range : >=4.5.0-6+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2025-8176
      https://scout.docker.com/v/CVE-2025-8176
      Affected range : >=4.5.0-6+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2024-6716
      https://scout.docker.com/v/CVE-2024-6716
      Affected range : >=4.5.0-6+deb12u1
      Fixed version  : not fixed

    x LOW CVE-2023-6228
      https://scout.docker.com/v/CVE-2023-6228
      Affected range : >=4.5.0-6+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2023-3164
      https://scout.docker.com/v/CVE-2023-3164
      Affected range : >=4.5.0-6+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2023-1916
      https://scout.docker.com/v/CVE-2023-1916
      Affected range : >=4.5.0-6+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2022-1210
      https://scout.docker.com/v/CVE-2022-1210
      Affected range : >=4.5.0-6+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2018-10126
      https://scout.docker.com/v/CVE-2018-10126
      Affected range : >=4.5.0-6+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2017-17973
      https://scout.docker.com/v/CVE-2017-17973
      Affected range : >=4.5.0-6+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2017-16232
      https://scout.docker.com/v/CVE-2017-16232
      Affected range : >=4.5.0-6+deb12u2
      Fixed version  : not fixed

    x UNSPECIFIED CVE-2023-38289
      https://scout.docker.com/v/CVE-2023-38289
      Affected range : >=4.5.0-6
      Fixed version  : not fixed

    x UNSPECIFIED CVE-2023-38288
      https://scout.docker.com/v/CVE-2023-38288
      Affected range : >=4.5.0-6
      Fixed version  : not fixed


   0C     1H     0M     2L  expat 2.5.0-1+deb12u2
pkg:deb/debian/expat@2.5.0-1%2Bdeb12u2?os_distro=bookworm&os_name=debian&os_version=12

    x HIGH CVE-2025-59375
      https://scout.docker.com/v/CVE-2025-59375
      Affected range : >=2.5.0-1+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2024-28757
      https://scout.docker.com/v/CVE-2024-28757
      Affected range : >=2.5.0-1+deb12u2
      Fixed version  : not fixed

    x LOW CVE-2023-52426
      https://scout.docker.com/v/CVE-2023-52426
      Affected range : >=2.5.0-1+deb12u2
      Fixed version  : not fixed


   0C     0H     1M     1L  tar 1.34+dfsg-1.2+deb12u1
pkg:deb/debian/tar@1.34%2Bdfsg-1.2%2Bdeb12u1?os_distro=bookworm&os_name=debian&os_version=12

    x MEDIUM CVE-2025-45582
      https://scout.docker.com/v/CVE-2025-45582
      Affected range : >=1.34+dfsg-1.2+deb12u1
      Fixed version  : not fixed

    x LOW CVE-2005-2541
      https://scout.docker.com/v/CVE-2005-2541
      Affected range : >=1.34+dfsg-1.2+deb12u1
      Fixed version  : not fixed


   0C     0H     0M     7L  glibc 2.36-9+deb12u13
pkg:deb/debian/glibc@2.36-9%2Bdeb12u13?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2019-9192
      https://scout.docker.com/v/CVE-2019-9192
      Affected range : >=2.36-9+deb12u13
      Fixed version  : not fixed

    x LOW CVE-2019-1010025
      https://scout.docker.com/v/CVE-2019-1010025
      Affected range : >=2.36-9+deb12u13
      Fixed version  : not fixed

    x LOW CVE-2019-1010024
      https://scout.docker.com/v/CVE-2019-1010024
      Affected range : >=2.36-9+deb12u13
      Fixed version  : not fixed

    x LOW CVE-2019-1010023
      https://scout.docker.com/v/CVE-2019-1010023
      Affected range : >=2.36-9+deb12u13
      Fixed version  : not fixed

    x LOW CVE-2019-1010022
      https://scout.docker.com/v/CVE-2019-1010022
      Affected range : >=2.36-9+deb12u13
      Fixed version  : not fixed

    x LOW CVE-2018-20796
      https://scout.docker.com/v/CVE-2018-20796
      Affected range : >=2.36-9+deb12u13
      Fixed version  : not fixed

    x LOW CVE-2010-4756
      https://scout.docker.com/v/CVE-2010-4756
      Affected range : >=2.36-9+deb12u13
      Fixed version  : not fixed


   0C     0H     0M     4L  openldap 2.5.13+dfsg-5
pkg:deb/debian/openldap@2.5.13%2Bdfsg-5?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2020-15719
      https://scout.docker.com/v/CVE-2020-15719
      Affected range : >=2.5.13+dfsg-5
      Fixed version  : not fixed

    x LOW CVE-2017-17740
      https://scout.docker.com/v/CVE-2017-17740
      Affected range : >=2.5.13+dfsg-5
      Fixed version  : not fixed

    x LOW CVE-2017-14159
      https://scout.docker.com/v/CVE-2017-14159
      Affected range : >=2.5.13+dfsg-5
      Fixed version  : not fixed

    x LOW CVE-2015-3276
      https://scout.docker.com/v/CVE-2015-3276
      Affected range : >=2.5.13+dfsg-5
      Fixed version  : not fixed


   0C     0H     0M     4L  systemd 252.39-1~deb12u1
pkg:deb/debian/systemd@252.39-1~deb12u1?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2023-31439
      https://scout.docker.com/v/CVE-2023-31439
      Affected range : >=252.39-1~deb12u1
      Fixed version  : not fixed

    x LOW CVE-2023-31438
      https://scout.docker.com/v/CVE-2023-31438
      Affected range : >=252.39-1~deb12u1
      Fixed version  : not fixed

    x LOW CVE-2023-31437
      https://scout.docker.com/v/CVE-2023-31437
      Affected range : >=252.39-1~deb12u1
      Fixed version  : not fixed

    x LOW CVE-2013-4392
      https://scout.docker.com/v/CVE-2013-4392
      Affected range : >=252.39-1~deb12u1
      Fixed version  : not fixed


   0C     0H     0M     3L  krb5 1.20.1-2+deb12u4
pkg:deb/debian/krb5@1.20.1-2%2Bdeb12u4?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2024-26461
      https://scout.docker.com/v/CVE-2024-26461
      Affected range : >=1.20.1-2+deb12u4
      Fixed version  : not fixed

    x LOW CVE-2024-26458
      https://scout.docker.com/v/CVE-2024-26458
      Affected range : >=1.20.1-2+deb12u4
      Fixed version  : not fixed

    x LOW CVE-2018-5709
      https://scout.docker.com/v/CVE-2018-5709
      Affected range : >=1.20.1-2+deb12u4
      Fixed version  : not fixed


   0C     0H     0M     2L  libheif 1.15.1-1+deb12u1
pkg:deb/debian/libheif@1.15.1-1%2Bdeb12u1?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2024-25269
      https://scout.docker.com/v/CVE-2024-25269
      Affected range : >=1.15.1-1+deb12u1
      Fixed version  : not fixed

    x LOW CVE-2023-49463
      https://scout.docker.com/v/CVE-2023-49463
      Affected range : >=1.15.1-1+deb12u1
      Fixed version  : not fixed


   0C     0H     0M     2L  curl 7.88.1-10+deb12u14
pkg:deb/debian/curl@7.88.1-10%2Bdeb12u14?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2025-0725
      https://scout.docker.com/v/CVE-2025-0725
      Affected range : >=7.88.1-10+deb12u14
      Fixed version  : not fixed

    x LOW CVE-2024-2379
      https://scout.docker.com/v/CVE-2024-2379
      Affected range : >=7.88.1-10+deb12u14
      Fixed version  : not fixed


   0C     0H     0M     2L  openssl 3.0.17-1~deb12u2
pkg:deb/debian/openssl@3.0.17-1~deb12u2?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2025-27587
      https://scout.docker.com/v/CVE-2025-27587
      Affected range : >=3.0.17-1~deb12u2
      Fixed version  : not fixed

    x LOW CVE-2010-0928
      https://scout.docker.com/v/CVE-2010-0928
      Affected range : >=3.0.11-1~deb12u2
      Fixed version  : not fixed


   0C     0H     0M     2L  coreutils 9.1-1
pkg:deb/debian/coreutils@9.1-1?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2025-5278
      https://scout.docker.com/v/CVE-2025-5278
      Affected range : >=9.1-1
      Fixed version  : not fixed

    x LOW CVE-2017-18018
      https://scout.docker.com/v/CVE-2017-18018
      Affected range : >=9.1-1
      Fixed version  : not fixed


   0C     0H     0M     2L  nginx 1.28.0-1~bookworm
pkg:deb/debian/nginx@1.28.0-1~bookworm?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2023-44487  CISA KEV 
      https://scout.docker.com/v/CVE-2023-44487
      Affected range : >=1.22.1-9+deb12u3
      Fixed version  : not fixed

    x LOW CVE-2009-4487
      https://scout.docker.com/v/CVE-2009-4487
      Affected range : >=1.22.1-9+deb12u3
      Fixed version  : not fixed


   0C     0H     0M     2L  libgcrypt20 1.10.1-3
pkg:deb/debian/libgcrypt20@1.10.1-3?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2024-2236
      https://scout.docker.com/v/CVE-2024-2236
      Affected range : >=1.10.1-3
      Fixed version  : not fixed

    x LOW CVE-2018-6829
      https://scout.docker.com/v/CVE-2018-6829
      Affected range : >=1.10.1-3
      Fixed version  : not fixed


   0C     0H     0M     2L  perl 5.36.0-7+deb12u3
pkg:deb/debian/perl@5.36.0-7%2Bdeb12u3?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2023-31486
      https://scout.docker.com/v/CVE-2023-31486
      Affected range : >=5.36.0-7+deb12u3
      Fixed version  : not fixed

    x LOW CVE-2011-4116
      https://scout.docker.com/v/CVE-2011-4116
      Affected range : >=5.36.0-7+deb12u3
      Fixed version  : not fixed


   0C     0H     0M     1L  util-linux 2.38.1-5+deb12u3
pkg:deb/debian/util-linux@2.38.1-5%2Bdeb12u3?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2022-0563
      https://scout.docker.com/v/CVE-2022-0563
      Affected range : >=2.38.1-5+deb12u3
      Fixed version  : not fixed


   0C     0H     0M     1L  jbigkit 2.1-6.1
pkg:deb/debian/jbigkit@2.1-6.1?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2017-9937
      https://scout.docker.com/v/CVE-2017-9937
      Affected range : >=2.1-6.1
      Fixed version  : not fixed


   0C     0H     0M     1L  libpng1.6 1.6.39-2
pkg:deb/debian/libpng1.6@1.6.39-2?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2021-4214
      https://scout.docker.com/v/CVE-2021-4214
      Affected range : >=1.6.39-2
      Fixed version  : not fixed


   0C     0H     0M     1L  libxml2 2.9.14+dfsg-1.3~deb12u4
pkg:deb/debian/libxml2@2.9.14%2Bdfsg-1.3~deb12u4?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2025-8732
      https://scout.docker.com/v/CVE-2025-8732
      Affected range : >=2.9.14+dfsg-1.3~deb12u4
      Fixed version  : not fixed


   0C     0H     0M     1L  gcc-12 12.2.0-14+deb12u1
pkg:deb/debian/gcc-12@12.2.0-14%2Bdeb12u1?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2022-27943
      https://scout.docker.com/v/CVE-2022-27943
      Affected range : >=12.2.0-14+deb12u1
      Fixed version  : not fixed


   0C     0H     0M     1L  gnutls28 3.7.9-2+deb12u5
pkg:deb/debian/gnutls28@3.7.9-2%2Bdeb12u5?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2011-3389
      https://scout.docker.com/v/CVE-2011-3389
      Affected range : >=3.7.9-2+deb12u5
      Fixed version  : not fixed


   0C     0H     0M     1L  gnupg2 2.2.40-1.1+deb12u1
pkg:deb/debian/gnupg2@2.2.40-1.1%2Bdeb12u1?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2022-3219
      https://scout.docker.com/v/CVE-2022-3219
      Affected range : >=2.2.40-1.1+deb12u1
      Fixed version  : not fixed


   0C     0H     0M     1L  shadow 1:4.13+dfsg1-1+deb12u1
pkg:deb/debian/shadow@1%3A4.13%2Bdfsg1-1%2Bdeb12u1?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2007-5686
      https://scout.docker.com/v/CVE-2007-5686
      Affected range : >=1:4.13+dfsg1-1+deb12u1
      Fixed version  : not fixed


   0C     0H     0M     1L  apt 2.6.1
pkg:deb/debian/apt@2.6.1?os_distro=bookworm&os_name=debian&os_version=12

    x LOW CVE-2011-3374
      https://scout.docker.com/v/CVE-2011-3374
      Affected range : >=2.6.1
      Fixed version  : not fixed



      https://scout.docker.com/v/CVE-2011-3374
      Affected range : >=2.6.1
      Fixed version  : not fixed
      https://scout.docker.com/v/CVE-2011-3374
      Affected range : >=2.6.1
      Fixed version  : not fixed


      https://scout.docker.com/v/CVE-2011-3374
      Affected range : >=2.6.1
      https://scout.docker.com/v/CVE-2011-3374
      Affected range : >=2.6.1
      Fixed version  : not fixed



66 vulnerabilities found in 24 packages
  CRITICAL     0
  HIGH         3
  MEDIUM       2
  LOW          59
  UNSPECIFIED  2


What's next:
    View base image update recommendations → docker scout recommendations nginx:stable

```

Agora, vamos analisar a imagem `nginx:stable-alpine` para comparar os resultados.

{% include code-header.html %}
```bash
docker scout cves nginx:stable-alpine
```

{% include code-header.html %}
```markdown
	i New version 1.18.3 available (installed version is 1.17.0) at https://github.com/docker/scout-cli
    v SBOM of image already cached, 83 packages indexed
    x Detected 5 vulnerable packages with a total of 8 vulnerabilities


## Overview

                    │       Analyzed Image
────────────────────┼──────────────────────────────
  Target            │  nginx:stable-alpine 
    digest          │  8f2bcf97c473 
    platform        │ linux/amd64
    vulnerabilities │    0C     2H     4M     2L 
    size            │ 21 MB
    packages        │ 83


## Packages and Vulnerabilities

   0C     1H     0M     0L  curl 8.12.1-r1
pkg:apk/alpine/curl@8.12.1-r1?os_name=alpine&os_version=3.21

    x HIGH CVE-2025-5399
      https://scout.docker.com/v/CVE-2025-5399
      Affected range : <=8.12.1-r1
      Fixed version  : not fixed


   0C     1H     0M     0L  expat 2.7.0-r0
pkg:apk/alpine/expat@2.7.0-r0?os_name=alpine&os_version=3.21

    x HIGH CVE-2025-59375
      https://scout.docker.com/v/CVE-2025-59375
      Affected range : <2.7.2-r0
      Fixed version  : 2.7.2-r0


   0C     0H     2M     0L  libavif 1.0.4-r0
pkg:apk/alpine/libavif@1.0.4-r0?os_name=alpine&os_version=3.21

    x MEDIUM CVE-2025-48175
      https://scout.docker.com/v/CVE-2025-48175
      Affected range : <=1.0.4-r0
      Fixed version  : not fixed

    x MEDIUM CVE-2025-48174
      https://scout.docker.com/v/CVE-2025-48174
      Affected range : <=1.0.4-r0
      Fixed version  : not fixed


   0C     0H     2M     0L  tiff 4.7.0-r0
pkg:apk/alpine/tiff@4.7.0-r0?os_name=alpine&os_version=3.21

    x MEDIUM CVE-2025-9165
      https://scout.docker.com/v/CVE-2025-9165
      Affected range : <4.7.1-r0
      Fixed version  : 4.7.1-r0

    x MEDIUM CVE-2025-8961
      https://scout.docker.com/v/CVE-2025-8961
      Affected range : <4.7.1-r0
      Fixed version  : 4.7.1-r0


   0C     0H     0M     2L  busybox 1.37.0-r12
pkg:apk/alpine/busybox@1.37.0-r12?os_name=alpine&os_version=3.21

    x LOW CVE-2025-46394
      https://scout.docker.com/v/CVE-2025-46394
      Affected range : <=1.37.0-r13
      Fixed version  : not fixed

    x LOW CVE-2024-58251
      https://scout.docker.com/v/CVE-2024-58251
      Affected range : <=1.37.0-r13
      Fixed version  : not fixed



8 vulnerabilities found in 5 packages
  CRITICAL  0
  HIGH      2
  MEDIUM    4
  LOW       2


What's next:
    View base image update recommendations → docker scout recommendations nginx:stable-alpine
```


Com esses resultados podemos ver que a imagem `nginx:stable` possui **66 vulnerabilidades em 24 pacotes**, enquanto a imagem `nginx:stable-alpine` possui apenas **8 vulnerabilidades em 5 pacotes**. Isso demonstra que a imagem baseada em Alpine Linux é mais leve e possui menos vulnerabilidades conhecidas.

Além disso, o **Docker Scout** fornece recomendações para atualizar a imagem base, o que ajuda a manter a segurança das suas aplicações. Podemos ver essas recomendações utilizando o comando abaixo:

{% include code-header.html %}
```cmd
docker scout recommendations nginx:stable
```

{% include code-header.html %}
```markdown
i New version 1.18.3 available (installed version is 1.17.0) at https://github.com/docker/scout-cli
    v SBOM of image already cached, 239 packages indexed

    i Base image was auto-detected. To get more accurate recommendations, build images with max-mode provenance attestations.
      Review docs.docker.com ↗ for more information.
      Alternatively, use  docker scout recommendations --tag <base image tag>  to pass a specific base image tag.

  Target   │  nginx:stable   
    digest │  2945a0bfa07b   

## Recommended fixes

  Base image is  debian:12-slim 

  Name            │  12-slim 
  Digest          │  sha256:acd98e6cfc42813a4db9ca54ed79b6f702830bfc2fa43a2c2e87517371d82edb   
  Vulnerabilities │    0C     0H     1M    24L 
  Pushed          │ 3 weeks ago
  Size            │ 28 MB
  Packages        │ 126
  Flavor          │ debian
  OS              │ 12
  Slim            │ v


  │ The base image is also available under the supported tag(s)  
  │ 12.12-slim ,  bookworm-20250908-slim ,  bookworm-slim . If you want
  │ to display recommendations specifically for a different tag,
  │ please re-run the command using the  --tag  flag.



Refresh base image
  Rebuild the image using a newer base image version. Updating this may result in breaking changes.

  v This image version is up to date.


Change base image
  The list displays new recommended tags in descending order, where the top results are rated as most suitable.


                    Tag                    │                        Details                        │   Pushed    │       Vulnerabilities     

───────────────────────────────────────────┼───────────────────────────────────────────────────────┼─────────────┼──────────────────────────────
   stable-slim                             │ Benefits:                                             │ 3 weeks ago │    0C     0H     1M    20L   
  Tag is preferred tag                     │ • Same OS detected                                    │             │                         -4

  Also known as:                           │ • Image contains 15 fewer packages                    │             │                           

  • stable-20250908-slim                   │ • Tag is preferred tag                                │             │                           

                                           │ • Image has similar size                              │             │                           

                                           │ • Image introduces no new vulnerability but removes 4 │             │                           

                                           │ • Tag is using slim variant                           │             │                           

                                           │ • stable-slim was pulled 46K times last month         │             │                           

                                           │                                                       │             │                           

                                           │ Image details:                                        │             │                           

                                           │ • Size: 30 MB                                         │             │                           

                                           │ • Flavor: debian                                      │             │                           

                                           │ • OS: 12                                              │             │                           

                                           │ • Slim: v                                             │             │                           

                                           │                                                       │             │                           

                                           │                                                       │             │                           

                                           │                                                       │             │                           

   13-slim                                 │ Benefits:                                             │ 3 weeks ago │    0C     0H     1M    20L   
  Major OS version update                  │ • Same OS detected                                    │             │                         -4

  Also known as:                           │ • Image contains 15 fewer packages                    │             │                           

  • 13.1-slim                              │ • Image has similar size                              │             │                           

  • trixie-slim                            │ • Image introduces no new vulnerability but removes 4 │             │                           

  • trixie-20250908-slim                   │ • Major OS version update                             │             │                           

                                           │ • Tag is using slim variant                           │             │                           

                                           │                                                       │             │                           

                                           │ Image details:                                        │             │                           

                                           │ • Size: 30 MB                                         │             │                           

                                           │ • OS: 13.1                                            │             │                           

                                           │                                                       │             │                           

                                           │                                                       │             │                           

                                           │                                                       │             │                           

   13                                      │ Benefits:                                             │ 3 weeks ago │    0C     0H     1M    20L   
  Tag is latest                            │ • Same OS detected                                    │             │                         -4

  Also known as:                           │ • Image contains 15 fewer packages                    │             │                           

  • 13.1                                   │ • Tag is latest                                       │             │                           

  • latest                                 │ • Image introduces no new vulnerability but removes 4 │             │                           

  • trixie                                 │ • Major OS version update                             │             │                           

  • trixie-20250908                        │                                                       │             │                           

                                           │ Image details:                                        │             │                           

                                           │ • Size: 49 MB                                         │             │                           

                                           │ • OS: 13.1                                            │             │                           

                                           │                                                       │             │                           

                                           │                                                       │             │                           

                                           │                                                       │             │                           

   12                                      │ Benefits:                                             │ 3 weeks ago │    0C     0H     1M    24L   
  Image has same number of vulnerabilities │ • Same OS detected                                    │             │                           

  Also known as:                           │ • Image has same number of vulnerabilities            │             │                           

  • 12.12                                  │ • Image contains equal number of packages             │             │                           

  • bookworm                               │                                                       │             │                           

  • bookworm-20250908                      │ Image details:                                        │             │                           

                                           │ • Size: 48 MB                                         │             │                           

                                           │ • Flavor: debian                                      │             │                           

                                           │ • OS: 12                                              │             │                           

                                           │                                                       │             │                           

                                           │                                                       │             │                           

                                           │                                                       │             │                           
```

{% include code-header.html %}
```bash
docker scout recommendations nginx:stable-alpine
```
{% include code-header.html %}
```markdown
i New version 1.18.3 available (installed version is 1.17.0) at https://github.com/docker/scout-cli
    v SBOM of image already cached, 83 packages indexed

    i Base image was auto-detected. To get more accurate recommendations, build images with max-mode provenance attestations.
      Review docs.docker.com ↗ for more information.
      Alternatively, use  docker scout recommendations --tag <base image tag>  to pass a specific base image tag.

  Target   │  nginx:stable-alpine   
    digest │  8f2bcf97c473 

## Recommended fixes

  Base image is  :1.28-alpine-slim 

  Digest          │      
  Vulnerabilities │      
  Size            │ 0 B  
  Packages        │ 0    


Refresh base image
  Rebuild the image using a newer base image version. Updating this may result in breaking changes.

  v This image version is up to date.


Change base image
  The list displays new recommended tags in descending order, where the top results are rated as most suitable.

  v There are no tag recommendations at this time.
```
Vamos seguir as recomendações e trocar a imagem base, vamos ver se realmente teremos uma redução nas vulnerabilidades.

{% include code-header.html %}
```bash
docker scout cves nginx:1.28-alpine-slim 
```

{% include code-header.html %}
```markdown
i New version 1.18.3 available (installed version is 1.17.0) at https://github.com/docker/scout-cli
    v SBOM obtained from attestation, 25 packages found
    v Provenance obtained from attestation
    x Detected 1 vulnerable package with 2 vulnerabilities


## Overview

                    │                                       Analyzed Image
────────────────────┼─────────────────────────────────────────────────────────────────────────────────────────────
  Target            │  nginx:1.28-alpine-slim 
    digest          │  f011b028d9ab 
    platform        │ linux/amd64
    provenance      │ https://github.com/nginx/docker-nginx.git
                    │  9b549fdf936778810dbe95a4813899c60444ef1c 
    vulnerabilities │    0C     0H     0M     2L 
    size            │ 5.4 MB
    packages        │ 25
                    │
  Base image        │  oisupport/staging-amd64:d6e23073f4b495813850002976640faedc1db539b811668064b4cab2dc4e2865 
                    │  068a614df1cc 


## Packages and Vulnerabilities

   0C     0H     0M     2L  busybox 1.37.0-r12
pkg:apk/alpine/busybox@1.37.0-r12?os_name=alpine&os_version=3.21

stable/alpine-slim/Dockerfile (0:0)


    x LOW CVE-2025-46394
      https://scout.docker.com/v/CVE-2025-46394
      Affected range : <=1.37.0-r13
      Fixed version  : not fixed

    x LOW CVE-2024-58251
      https://scout.docker.com/v/CVE-2024-58251
      Affected range : <=1.37.0-r13
      Fixed version  : not fixed



2 vulnerabilities found in 1 package
  CRITICAL  0
  HIGH      0
  MEDIUM    0
  LOW       2


What's next:
    View base image update recommendations → docker scout recommendations nginx:1.28-alpine-slim
```

Legal, agora conseguimos reduzir de **8 vulnerabilidades** para apenas **2 vulnerabilidades**, outro ponto interessante é comparar os tamanhos das imagens, para isso podemos utilizar o comando `docker images` para listar as imagens que temos localmente.

{% include code-header.html %}
```bash
docker images
```

{% include code-header.html %}
```markdown
REPOSITORY   TAG                IMAGE ID       CREATED        SIZE
nginx        1.28-alpine-slim   f25f85213414   6 weeks ago    19.4MB
nginx        stable             2945a0bfa07b   6 weeks ago    279MB
nginx        stable-alpine      8f2bcf97c473   5 months ago   73.5MB
```

### Gerando o SBOM (Software Bill of Materials)

Vamos começar com o que é o SBOM. O *Software Bill of Materials* é uma lista detalhada de todos os componentes de software que estão incluídos em uma aplicação ou imagem Docker. Ele fornece visibilidade sobre as dependências e permite que possamos identificar rapidamente vulnerabilidades conhecidas, fazendo com que seja possível tomar medidas para mitigar os riscos de segurança. Uma dica é gerar o SBOM no formato JSON como um arquivo, isso facilita a análise e o compartilhamento das informações, principalmente porque os arquivos podem ser grandes.

Vamos seguir e gerar o SBOM em formato JSON para as imagens `nginx:stable` e `nginx:stable-alpine`.

{% include code-header.html %}
```bash
docker scout sbom nginx:stable --format json --output sbom-nginx-stable.json
# gerou um arquivo chamado sbom-nginx-stable.json com 13288 linhas
```

{% include code-header.html %}
```bash
docker scout sbom nginx:stable-alpine --format json --output sbom-nginx-stable-alpine.json
# gerou um arquivo chamado sbom-nginx-stable-alpine.json com 13099 linhas
```
